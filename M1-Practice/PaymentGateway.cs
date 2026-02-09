using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class PaymentRequest
{
    public decimal Amount;
}

class PaymentResult
{
    public bool Success;
    public string Message;
}

class PaymentGateway
{
    private static int failureCount = 0;
    private static DateTime windowStart = DateTime.MinValue;
    private static DateTime circuitOpenUntil = DateTime.MinValue;
    private static readonly object lockObj = new object();

    public async Task<PaymentResult> ProcessPaymentAsync(
        PaymentRequest request,
        CancellationToken cancellationToken)
    {
        
        if (DateTime.UtcNow < circuitOpenUntil)
        {
            return new PaymentResult
            {
                Success = false,
                Message = "Circuit open. Failing fast."
            };
        }

        int retries = 3;

        for (int attempt = 1; attempt <= retries; attempt++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                await SimulatePaymentAsync(cancellationToken);

                ResetFailures();
                return new PaymentResult
                {
                    Success = true,
                    Message = "Payment successful"
                };
            }
            catch (TimeoutException)
            {
                RegisterFailure();

                if (attempt == retries)
                    break;

                await Task.Delay(500, cancellationToken); // retry delay
            }
        }

        return new PaymentResult
        {
            Success = false,
            Message = "Payment failed after retries"
        };
    }

    //  Simulated payment call
    private async Task SimulatePaymentAsync(CancellationToken token)
    {
        await Task.Delay(300, token);

        // Random timeout
        if (new Random().Next(1, 3) == 1)
            throw new TimeoutException("Gateway timeout");
    }

    private void RegisterFailure()
    {
        lock (lockObj)
        {
            if (windowStart == DateTime.MinValue ||
                DateTime.UtcNow - windowStart > TimeSpan.FromMinutes(1))
            {
                windowStart = DateTime.UtcNow;
                failureCount = 0;
            }

            failureCount++;

            if (failureCount >= 5)
            {
                circuitOpenUntil = DateTime.UtcNow.AddSeconds(30);
                Console.WriteLine("🚨 Circuit opened for 30 seconds");
            }
        }
    }

    private void ResetFailures()
    {
        lock (lockObj)
        {
            failureCount = 0;
            windowStart = DateTime.MinValue;
        }
    }
}

public class ResilientPaymentGateway
{
    public static async Task Run()
    {
        var gateway = new PaymentGateway();
        var request = new PaymentRequest { Amount = 1000 };
        var cts = new CancellationTokenSource();

        try
        {
            PaymentResult result =
                await gateway.ProcessPaymentAsync(request, cts.Token);

            Console.WriteLine(result.Message);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Payment cancelled");
        }
    }
}
