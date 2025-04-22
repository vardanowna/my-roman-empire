namespace MyRomanEmpire.Models;

public class Todo
{
    public string name;
    public int id;

    public void newTodo()
    {
        Todo todo = new Todo();
    }
    
    public void removeTodo(id)
    {
        _todos.remove(_todos[id]);
    }
    
    public void showTodo()
    {
        foreach (var todo in _todos)
            Console.WriteLine(todo);
    }
    
    public void getTodo(id)
    {
        Console.WriteLine(_todos[id]);
    }
}