using System.Globalization;
using System.Text;
using MyRomanEmpire.Models;

namespace MyRomanEmpire.Repositories;

public class TodoRepository
{
    private readonly List<Todo> _todos = new List<Todo>();
    private int id = 1;
    public string localPath = "C:\\zakarian\\pet_projects\\my-roman-empire\\files\\";
    string localDate = DateTime.Now.ToString(new CultureInfo("en-GB")).Replace(" ", "_").Replace(":", "_").Replace("\\", "_");

    // Create name => id
    public int Create(Todo todo)
    {
        todo = new Todo(id, todo.Name);
        _todos.Add(todo);
        id += 1;
        return todo.Id;
    }

    // Get id => Todo or null
    public Todo? Get(int searchId)
    {
        var searchResultTodo = _todos.SingleOrDefault(x => x.Id == searchId);
        
        if (searchResultTodo == null)
        {
            Console.WriteLine("хьюстон, у нас нулл");
        }

        return searchResultTodo;
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

    public void Done(int searchId)
    {
        _todos.Single(x => x.Id == searchId).Status = State.Completed;
    }
    
    public void Undone(int searchId)
    {
        _todos.Single(x => x.Id == searchId).Status = State.New;
    }

    public IReadOnlyCollection<Todo> All()
    {
        return _todos.AsReadOnly();
    }
    public async void Save()
    {
        string fileName = "list_of_todos_" + localDate + ".txt";
        string fullPath = localPath + fileName;

        await using (var fs = File.Create(fullPath))
        {
            
        }

        await using (StreamWriter writer = new StreamWriter(fullPath, true))
        {
            foreach (Todo todo in _todos)
            {
                await writer.WriteLineAsync(todo.ToString());
            }
        }
    }
}

