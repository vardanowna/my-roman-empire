using Microsoft.AspNetCore.Mvc;
using MyRomanEmpire.Mappers;
using MyRomanEmpire.Models;
using MyRomanEmpire.Models.ApiModels;
using MyRomanEmpire.Repositories;

namespace MyRomanEmpire.Controllers;

[ApiController]
[Route("api/todos")]
public class TodoControllers : ControllerBase
{
    private readonly ITodoRepository _repository;
    
    public TodoControllers(ITodoRepository repository)
    {
        _repository = repository;
    }
    
    // private static readonly ITodoRepository repository = TodoRepositoryFactory.GetRepo(DateTime.Now.DayOfWeek);

    [HttpPost("create")]
    public CreateResponse CreateTodo([FromBody] CreateRequest request)
    {
        var todo = new Todo(request.TodoName); //ToDO: проверка на пустой ввод и на неуникальное имя
        var id = _repository.Create(todo);
        _repository.UpdateFile();

        return new CreateResponse()
        {
            Id = id,
        };
    }

    [HttpPut("to-in-progress/{todosId}")]
    public IActionResult ToInProgress([FromBody] string todosId) // может, сразу принимать только int?
    {
        int.TryParse(todosId, out var currentId);
        _repository.ToInProgressFromNew(currentId);
        _repository.UpdateFile();

        return Ok();
    }

    [HttpPut("to-done/{todosId}")]
    public IActionResult ToDone([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId);
        _repository.Done(currentId);
        _repository.UpdateFile();

        return Ok();
    }

    [HttpPut("return-to-in-progress/{todosId}")]
    public IActionResult ReturnToInProgress([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId);
        _repository.ToInProgressFromDone(currentId);
        _repository.UpdateFile();

        return Ok();
    }

    [HttpPut("reopen/{todosId}")]
    public IActionResult Reopen([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId);
        _repository.Reopen(currentId);
        _repository.UpdateFile();

        return Ok();
    }

    [HttpDelete("burn/{todosId}")]
    public IActionResult Burn([FromBody] string todosId)
    {
        int.TryParse(todosId, out var currentId);
        _repository.Burn(currentId); //ToDo: пересчитать id или взять из параллельного списка и смапить
        // ToDo: добавить обработку нуллового id
        _repository.UpdateFile();

        return Ok();
    }

    [HttpPut("edit/{todosId}")]
    public IActionResult Edit([FromBody] string todosId, string newName)
    {
        int.TryParse(todosId, out var currentId);
        _repository.Edit(currentId, newName); // ToDo: добавить обработку нуллового id
        //ToDo: добавить проверку на argument out of range
        _repository.UpdateFile();

        return Ok();
    }

    [HttpGet("all")]
    public GetAllResponse GetAll()
    {
        // var response = new GetAllResponse()
        // {
        //     Items = repository.All()
        //         .Where(it => it.Status != State.Completed)
        //         .Select(it => new GetAllItem()
        //         {
        //             Id = it.Id,
        //             Name = it.Name,
        //         }).ToList()
        // };
        var todos = _repository.All().ToArray();
        var response = new GetAllResponse();
        foreach (var todo in todos)
        {
            if (todo.Status != State.Completed)
            {
                response.Items.Add(todo.MapToResponse());
            }
        }

        return response;
    }

    [HttpGet("search")]
    public Todo? Search([FromQuery] string searchName)
    {
        var response = _repository.Search(searchName);
        var res1 = response?.MapToResponse();

        var w = new { ASdasd = 124, asdgfdfg = 234534, afsdawrt = "asdfsdafg" };

        return response;
    }

    [HttpGet("filter")]
    public IActionResult Filter([FromQuery] string state)
    {
        //Существуют следующие статусы: {State.New}, {State.InProgress}, {State.Completed};
        State.TryParse<State>(state, out var filterState);
        _repository.Filter(filterState);

        return Ok();
    }

    [HttpGet("get/{todosId}")]
    public IActionResult Get([FromRoute] string todosId)
    {
        int.TryParse(todosId, out var currentId);
        var currentTodo = _repository.Get(currentId);
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
        _repository.Save();

        return Ok();
    }

    [HttpPut("export")]
    public IActionResult Export()
    {
        _repository.Export();

        return Ok();
    }

    [HttpPut("import")]
    public IActionResult Import([FromBody] string path)
    {
        _repository.Import(path);

        return Ok();
    }

    [HttpGet("f")]
    public string F()
    {
        return "R.I.P.";
    }
}