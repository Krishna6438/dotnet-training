using System.Collections;
using System.Collections.Generic; 
interface IDisposable
{
    public void Dispose();
}
public class BigBoy : IDisposable
{
    public BigBoy()
    {

    }
    public ArrayList Names  { get; set; }
    public void Dispose()
    {
        GC.Collect();
    }
}
public class GarbageCollectionExample
{
    public static void Run ()
    {
        BigBoy bigboy = new();
        try
        {
            bigboy.Names = new System.Collections.ArrayList();
            for (int i = 0; i < 10; i++)
            {
                bigboy.Names.Add(i.ToString());
            }

        }
        catch (System.Exception)
        {
            throw;
        }
        finally
        {
            bigboy.Dispose();
        }
    }
}
