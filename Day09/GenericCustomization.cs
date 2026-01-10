
interface IList
{
    void Add(string s);
    
    void Remove(string item);
    int Count();
}

class CustomizeCollection : IList
{

    public List<string> items = new List<string>();
    public void Add(string item)
    {
        items.Add(item);
    }

    public void Remove(string item)
    {
        items.Remove(item);
    }

    public int Count()
    {
        return items.Count();
    }
}


class MyCollection
{
    public static void Run()
    {
        IList c = new CustomizeCollection();
        c.Add("ABC");
        c.Add("BBA");

        Console.WriteLine("Total Items: " + c.Count());
    }
}