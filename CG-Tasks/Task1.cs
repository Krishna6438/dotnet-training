namespace Task
{
    class Employee
    {
        public int Id{get; set;}
        public string Name {get; set;}

        Employee(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public void printDetails()
        {
            Console.WriteLine($"{Id} {Name}");
        }

        
    }


}
