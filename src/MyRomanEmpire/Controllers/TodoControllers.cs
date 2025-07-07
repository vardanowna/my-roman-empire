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
    private static readonly TodoRepository repository = new TodoRepository();

    [HttpPost("create")]
    public CreateResponse CreateTodo([FromBody] CreateRequest request)
    {

        var todo = new Todo(request.TodoName); //ToDO: проверка на пустой ввод и на неуникальное имя
        var id = repository.Create(todo);
        repository.UpdateFile();

        return new CreateResponse()
        {
            Id = id,
        };
    }
    
    [HttpPut("to-in-progress")]
    public ToInProgressResponse ToInProgress([FromBody] ToInProgressRequest request) // может, сразу принимать только int?
    {
        var id = request.Id;
        repository.ToInProgressFromNew(id);
        repository.UpdateFile();

        return new ToInProgressResponse()
        {
            Id = id,
        }; 
    }
    
    [HttpPut("to-done")]
    public ToDoneResponse ToDone([FromBody] ToDoneRequest request)
    {
        var id = request.Id; 
        repository.Done(id);
        repository.UpdateFile();
        
        return new ToDoneResponse()
        {
            Id = id,
        }; 
    }
    
    [HttpPut("return-to-in-progress")]
    public ReturnToInProgressResponse ReturnToInProgress([FromBody] ReturnToInProgressRequest request)
    {
        var id = request.Id;  
        repository.ToInProgressFromDone(id);
        repository.UpdateFile();

        return new ReturnToInProgressResponse()
        {
            Id = id,
        };
    }
    
    [HttpPut("reopen")]
    public ReopenResponse Reopen([FromBody] ReopenRequest request)
    {
        var id = request.Id;
        repository.Reopen(id);
        repository.UpdateFile();

        return new ReopenResponse()
        {
            Id = id,
        };
    }
    
    [HttpDelete("burn")]
    public BurnResponse Burn([FromBody] BurnRequest request)
    {
        var id = request.Id;
        repository.Burn(id); //ToDo: пересчитать id или взять из параллельного списка и смапить
        // ToDo: добавить обработку нуллового id
        repository.UpdateFile();

        return new BurnResponse()
        {
            Id = id,
        };
    }
    
    [HttpPut("edit")]
    public EditResponse Edit([FromBody] EditRequest request)
    {
        var id = request.Id;
        var newName = request.TodoName;
        repository.Edit(id, newName); // ToDo: добавить обработку нуллового id
        //ToDo: добавить проверку на argument out of range
        repository.UpdateFile();

        return new EditResponse()
        {
            Id = id,
        };
    }
    
    [HttpGet("all")]
    public GetAllResponse GetAll()
    {
        var todos = repository.All().ToArray();
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
    public SearchResponse Search([FromBody] SearchRequest request)
    {
        var id = repository.Search(request.TodoName).Id;

        return new SearchResponse()
        {
            Id = id,
        };
    }
    
    [HttpGet("filter")]
    public FilterResponse Filter([FromBody] FilterRequest request)
    {
        //Существуют следующие статусы: {State.New}, {State.InProgress}, {State.Completed};
        State state = request.State;
        repository.Filter(state);

        return new FilterResponse() //ToDo: ?
        {

        };
    }
    
    [HttpGet("get")]
    public GetResponse Get([FromBody] GetRequest request)
    {
        var id = request.Id;
        var currentTodo = repository.Get(id);
        if (currentTodo == null)
        {
            return new GetResponseError()
            {
                //ToDo: ?
            };
        }
        else
            return new GetResponse()
            {
                Id = id,
            };
    
    [HttpPut("save")]
    public SaveResponse Save()
    {
        repository.Save();

        return new SaveResponse()
        {
            //ToDo: ?
        };
    }
    
    [HttpPut("export")]
    public Exportresponse Export()
    {
        repository.Export();
        
        return new Exportresponse()
        {
            //ToDo: ?
        };
    }
    
    [HttpPut("import")]
    public ImportResponse Import([FromBody] string path)
    {
        repository.Import(path);

        return new ImportResponse()
        {
            //ToDo: ?
        };
    }
    
    [HttpGet("f")]
    public string F()
    {
        return "R.I.P.";
    }
}