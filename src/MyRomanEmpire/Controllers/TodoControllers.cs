using Microsoft.AspNetCore.Mvc;
using MyRomanEmpire.Models;
using MyRomanEmpire.Repositories;

namespace MyRomanEmpire.Controllers;

[ApiController]
[Route("api/todos")]
public class TodoControllers : ControllerBase
{
    private static readonly TodoRepository repository = new TodoRepository();

    [HttpPost("create")]
    public IActionResult CreateTodo([FromBody] string todosName)
    {

        var name = todosName;
        var todo = new Todo(name); //ToDO: проверка на пустой ввод и на неуникальное имя
        repository.Create(todo);
        repository.UpdateFile();

        return Ok();
    }
    
    [HttpPut("to-in-progress/{todosId}")]
    public IActionResult ToInProgress([FromBody] string todosId) // может, сразу принимать только int?
    {
        int.TryParse(todosId, out var currentId); 
        repository.ToInProgressFromNew(currentId);
        repository.UpdateFile();

        return Ok();
    }
    
    [HttpPut("to-done/{todosId}")]
    public IActionResult ToDone([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId); 
        repository.Done(currentId);
        repository.UpdateFile();
        
        return Ok();
    }
    
    [HttpPut("return-to-in-progress/{todosId}")]
    public IActionResult ReturnToInProgress([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId); 
        repository.ToInProgressFromDone(currentId);
        repository.UpdateFile();

        return Ok();
    }
    
    [HttpPut("reopen/{todosId}")]
    public IActionResult Reopen([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId); 
        repository.Reopen(currentId);
        repository.UpdateFile();

        return Ok();
    }
    
    [HttpDelete("burn/{todosId}")]
    public IActionResult Burn([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId);
        repository.Burn(currentId); //ToDo: пересчитать id или взять из параллельного списка и смапить
        // ToDo: добавить обработку нуллового id
        repository.UpdateFile();

        return Ok();
    }
    
    [HttpPut("edit/{todosId}")]
    public IActionResult Edit([FromBody] string todosId, string newName)
    {
        int.TryParse(todosId, out var currentId);
        repository.Edit(currentId, newName); // ToDo: добавить обработку нуллового id
        //ToDo: добавить проверку на argument out of range
        repository.UpdateFile();

        return Ok();
    }
    
    [HttpGet("all")]
    public IActionResult Edit()
    {
        foreach (Todo todo in repository.All())
        {
            if (todo.Status != State.Completed)
            {
                Console.WriteLine(todo);
            }
        }

        return Ok();
    }
    
    [HttpGet("search/{todosId}")]
    public IActionResult Search([FromQuery] string searchName)
    {
        repository.Search(searchName);

        return Ok();
    }
    
    [HttpGet("filter/{state}")]
    public IActionResult Filter([FromQuery] string state)
    {
        //Существуют следующие статусы: {State.New}, {State.InProgress}, {State.Completed};
        State.TryParse<State>(state, out var filterState); 
        repository.Filter(filterState);

        return Ok();
    }
    
    [HttpGet("get/{todosId}")]
    public IActionResult Get([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId);
        var currentTodo = repository.Get(currentId);
        if (currentTodo == null)
        {
            return BadRequest();
        }
        else
        {
            return Ok();
        }
    }
    
    [HttpPut("save")]
    public IActionResult Save()
    {
        repository.Save();

        return Ok();
    }
    
    [HttpPut("export")]
    public IActionResult Export()
    {
        repository.Export();
        
        return Ok();
    }
    
    [HttpPut("import")]
    public IActionResult Import([FromBody] string path)
    {
        repository.Import(path);

        return Ok();
    }
    
    [HttpGet("f")]
    public string F()
    {
        return "R.I.P.";
    }
}