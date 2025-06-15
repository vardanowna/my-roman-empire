using Microsoft.AspNetCore.Mvc;
using MyRomanEmpire.Models;
using MyRomanEmpire.Repositories;

namespace MyRomanEmpire.Controllers;

[ApiController]
[Route("api/todos")]
public class TodoControllers : ControllerBase
{
    private static readonly TodoRepository repository = new TodoRepository();

    [HttpPost("{create}")]
    public Todo CreateTodo([FromBody] string todosName)
    {

        var name = todosName;
        var todo = new Todo(name); //ToDO: проверка на пустой ввод и на неуникальное имя
        repository.Create(todo);
        repository.UpdateFile();

        return todo;
    }
    
    [HttpPut("to-in-progress/{todosId}")]
    public Todo ToInProgress([FromBody] string todosId) // может, сразу принимать только int?
    {
        int.TryParse(todosId, out var currentId); 
        repository.ToInProgressFromNew(currentId);
        repository.UpdateFile();

        return Ok;
    }
    
    [HttpPut("to-done/{todosId}")]
    public Todo ToDone([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId); 
        repository.Done(currentId);
        repository.UpdateFile();
        
        return Ok;
    }
    
    [HttpPut("return-to-in-progress/{todosId}")]
    public Todo ReturnToInProgress([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId); 
        repository.ToInProgressFromDone(currentId);
        repository.UpdateFile();

        return Ok;
    }
    
    [HttpPut("reopen/{todosId}")]
    public Todo Reopen([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId); 
        repository.Reopen(currentId);
        repository.UpdateFile();

        return Ok;
    }
    
    [HttpDelete("burn/{todosId}")]
    public Todo Burn([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId);
        repository.Burn(currentId); //ToDo: пересчитать id или взять из параллельного списка и смапить
        // ToDo: добавить обработку нуллового id
        repository.UpdateFile();

        return Ok;
    }
    
    [HttpPut("edit/{todosId}")]
    public Todo Edit([FromBody] string todosId, string newName)
    {
        int.TryParse(todosId, out var currentId);
        repository.Edit(currentId, newName); // ToDo: добавить обработку нуллового id
        //ToDo: добавить проверку на argument out of range
        repository.UpdateFile();

        return Ok;
    }
    
    [HttpGet("all")]
    public Todo Edit()
    {
        foreach (Todo todo in repository.All())
        {
            if (todo.Status != State.Completed)
            {
                Console.WriteLine(todo);
            }
        }

        return Ok;
    }
    
    [HttpGet("search/{todosId}")]
    public Todo Search([FromQuery] string searchName)
    {
        repository.Search(searchName);

        return Ok;
    }
    
    [HttpGet("filter/{state}")]
    public Todo Filter([FromQuery] string state)
    {
        //Существуют следующие статусы: {State.New}, {State.InProgress}, {State.Completed};
        State.TryParse<State>(state, out var filterState); 
        repository.Filter(filterState);

        return Ok;
    }
    
    [HttpGet("get/{todosId}")]
    public string Get([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId);
        var currentTodo = repository.Get(currentId);
        if (currentTodo == null)
        {
            return "ну ты и дурачок, конечно";
        }
        else
        {
            return currentTodo.ToString();
        }
    }
    
    [HttpPut("save")]
    public Todo Save()
    {
        repository.Save();

        return Ok;
    }
    
    [HttpPut("export")]
    public Todo Export()
    {
        repository.Export();
        
        return Ok;
    }
    
    [HttpPut("import")]
    public Todo Import([FromBody] string path)
    {
        repository.Import(path);

        return Ok;
    }
    
    [HttpGet("f")]
    public string F()
    {
        return "R.I.P.";
    }
}