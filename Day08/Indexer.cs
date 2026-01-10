class MyData
{
    private string [] values = new string[3];

    public string this[int index]
    {
        get
        {
            return values[index];
        }
        set
        {
            values[index] = value;  // value -> contextual keyword
        }
    }
}

class IndexerExample1
{
    public static void Run()
    {
        MyData obj = new MyData();
        obj[0] = "C";
        obj[1] = "C++";
        obj[2] = "C#";

        Console.WriteLine("First Value: "+obj[0]);
        Console.WriteLine("First Value: "+obj[1]);
        Console.WriteLine("First Value: "+obj[2]);   

    }
}