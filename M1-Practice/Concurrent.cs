using System;
using System.Threading.Tasks;

public class Seat
{
    public int SeatNo;
    public bool IsBooked;
}

public class TicketBooking
{
    private Seat seat = new Seat { SeatNo = 1, IsBooked = false };
    private readonly object lockObj = new object();

    public bool BookSeat(int seatNo, string userId)
    {
        lock (lockObj)   //  thread-safe block
        {
            if (seat.SeatNo != seatNo)
                return false;

            if (seat.IsBooked)
                return false;

            seat.IsBooked = true;
            Console.WriteLine($"Seat booked by {userId}");
            return true;
        }
    }
}

public class ConcurrentTicketBooking
{
    public static void Run()
    {
        TicketBooking booking = new TicketBooking();

        Parallel.Invoke(
            () => Console.WriteLine(booking.BookSeat(1, "UserA")),
            () => Console.WriteLine(booking.BookSeat(1, "UserB"))
        );
    }
}
