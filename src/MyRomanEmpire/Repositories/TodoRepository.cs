using System.Globalization;
using System.Text;
using System.IO;
using MyRomanEmpire.Models;

namespace MyRomanEmpire.Repositories;

public class TodoRepository
{
    private readonly List<Todo> _todos = new List<Todo>();
    private int id = 1;
    public string localPath = "C:\\zakarian\\pet_projects\\my-roman-empire\\files\\list_of_todos.txt";
    //string localDate = DateTime.Now.ToString(new CultureInfo("en-GB")).Replace(" ", "_").Replace(":", "_").Replace("/", "_");
    // public string debugPath = "C:\\zakarian\\pet_projects\\my-roman-empire\\files\\test.txt";
    

    public void Init()
    {
        if (File.Exists(localPath))
        {
            File.Create(localPath).Close();
        }
    }

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
        //string fileName = "list_of_todos_" + localDate + ".txt";
        //string fullPath = localPath + fileName;
        await File.WriteAllTextAsync(localPath, "");

        await using (StreamWriter writer = new StreamWriter(localPath, true))
        {
            foreach (Todo todo in _todos)
            {
                await writer.WriteLineAsync(todo.ToString());
            }
            Console.WriteLine("ура! теперь твои тудусы живут в файле!");
        }
    }
    
    public async void Import(string path)
    {
        id = 0;
        _todos.Clear();
        
        await File.WriteAllTextAsync(localPath, "");
        string[] lines = await File.ReadAllLinesAsync(path);
        
        foreach (string line in lines)
        {
            int spaceIndex = line.IndexOf(' ');
            int importLineId = Convert.ToInt32(line[..(spaceIndex-1)]);
            string importLineName = line[(spaceIndex + 1)..line.Length];
            Todo todo = new Todo(importLineId, importLineName);
            _todos.Add(todo);
            await File.AppendAllTextAsync(localPath, todo +"\n");
            id += 1;
        }
        Console.WriteLine("ура! тудусы из файла загружены!");
    }
    
    public async void Export()
    {
        Console.WriteLine("Under reconstruction...");
    }
}

