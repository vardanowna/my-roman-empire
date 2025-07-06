using MyRomanEmpire.Models;
using MyRomanEmpire.Models.ApiModels;

namespace MyRomanEmpire.Mappers;

public static class TodoControllerMapper
{
    public static GetAllItem MapToResponse(this Todo todo)
    {
        return new GetAllItem()
        {
            Id = todo.Id,
            Name = todo.Name,
        };
    }
}