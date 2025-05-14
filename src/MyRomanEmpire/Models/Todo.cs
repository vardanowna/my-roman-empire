namespace MyRomanEmpire.Models;

public class Todo
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int Status { get; set; }

    public Todo(int id, string name)
    {
        Id = id;
        Name = name;
        Status = 0;
    }
    
    public Todo(string name)
    {
        Id = 0;
        Name = name;
        Status = 0;
    }

    public override string ToString()
    {
        return $"{Id} - {Name}";
    }
}