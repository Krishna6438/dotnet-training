namespace MultipleInheritance ;
interface IVegEatter
    {
        public void VegEatter();
        string GetTaste();
    }

    interface INonVegEatter
    {
        public void NonVegEatter();
        string GetTaste();
    }
    public class Visitor:INonVegEatter, IVegEatter
    {
        public void NonVegEatter()
        {
            Console.WriteLine("I eat non veg food.");
        }
        public void VegEatter()
        {
            Console.WriteLine("I eat veg food.");
        }
        string INonVegEatter.GetTaste()
        {
            return "Non veg taste is rank 2.";
        }

        string IVegEatter.GetTaste()
        {
            return "Veg taste is rank 1.";
        }
    }

class MultipleInheritanceClass
{
    public static void Run()
    {
        
        Visitor visitor=new Visitor();
        visitor.NonVegEatter();
        visitor.VegEatter();

        IVegEatter vegEatter=new Visitor();
        string vTaste=vegEatter.GetTaste();

        INonVegEatter nonVegEatter=new Visitor();
        string nvTaste=nonVegEatter.GetTaste();
        Console.WriteLine(vTaste);
        Console.WriteLine(nvTaste);
    }
}