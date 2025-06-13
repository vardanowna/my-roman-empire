using Microsoft.AspNetCore.Mvc;
using MyRomanEmpire.Models;

namespace MyRomanEmpire.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoControllers : ControllerBase
{
    
    [HttpPost]
    public Todo CreateTodo()
    {
        Console.WriteLine("как назовём засранца?");
        var name = Console.ReadLine();
        var todo = new Todo(name); //ToDO: проверка на пустой ввод и на неуникальное имя
        repository.Create(todo);
        Console.WriteLine($"да прибудет с нами новый тудус: {todo.Name}...");
        repository.UpdateFile();
    }
}