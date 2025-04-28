namespace MyRomanEmpire.Models;

public class Todo
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Todo(int id, string name)
    {
        Id = id;
        Name = name;
    }
}