namespace MyRomanEmpire.Models;

public class Todo
{
    public int Id { get; set; }
    public string Name { get; set; }

    // public static string Colour { get; set; }

    public void DoSMTH()
    {
        
    }

    public static void AnothertDoSMTH()
    {
        
    }


    public Todo(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Id} - {Name}";
    }
}