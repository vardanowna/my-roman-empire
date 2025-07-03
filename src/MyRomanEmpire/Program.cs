using MyRomanEmpire.Models;
using MyRomanEmpire.Repositories;

namespace MyRomanEmpire;

public class Program // слой представления
{
    //private static readonly TodoRepository repository = new TodoRepository();
    
    public static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt => { });
        
        var app = builder.Build();

        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI(opt =>
        {
            opt.SwaggerEndpoint("/swagger/v1/swagger.json", "MyRomanEmpire");
            opt.RoutePrefix = string.Empty;
        });

        app.MapControllers();
        app.Run();
        
    }
}