using MyRomanEmpire.Models;

namespace MyRomanEmpire.Repositories;

public class TodoRepository
{
    private readonly List<Todo> _todos = new List<Todo>();
    private int id = 0;
    public int TodosLen = _todos.Count;

    // Create name => id
    public int Create(Todo todo)
    {
        todo = new Todo(id, todo.Name);
        _todos.Add(todo);
        id += 1;
        return todo.Id;
    }

    // Get id => Todo or null
    public Todo Get(int searchId)
    {
        var searchResultTodo = _todos.SingleOrDefault(x => x.Id == searchId);
        if (searchResultTodo == null)
        {
            Console.WriteLine("хьюстон, у нас нулл");
        }
        else
        {
            return searchResultTodo;
        }
    }
    
    // Edit id, name => можно void, можно success or fail
    public string Edit(int searchId, string newName)
    {
        _todos.Single(x => x.Id == searchId).Name = newName.ToString();
        if (_todos[searchId].Name == newName)
        {
            return "получилося";
        }
        else
        {
            return "не получилося";
        }
    }

    // Burn id => можно void, можно success or fail
    public string Burn(int searchId)
    {
        _todos.Remove(_todos.Single(x => x.Id == searchId));
        
        if (_todos[searchId] == null)
        {
            return "получилося";
        }
        else
        {
            return "не получилося";
        }
    }
}