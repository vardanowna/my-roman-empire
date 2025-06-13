using MyRomanEmpire.Models;
using MyRomanEmpire.Repositories;

namespace MyRomanEmpire;

public class Program // слой представления
{
    private static readonly TodoRepository repository = new TodoRepository();
    
    public static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapControllers();

        app.Run();
        
        /*
        repository.Init();
        repository.Import(repository.localPath);
        
        Console.WriteLine("тудусы приветствуют тебя...");
        Console.WriteLine("если нужна помощь, скажи help...");
        
        while (true)
        {
            Console.WriteLine("что дальше?....");
            var input = Console.ReadLine(); // ToDo: добавить проверку на пустую строку
            var splitedInput = input.Split(" "); // ToDo: проверка на null

            var command = splitedInput[0]; // ToDo: добавить проверку на пустоту //ToDo: добвить проверку на argument out of range
            //var parameters = splitedInput[1]; // ToDo: добавить проверку на пустоту //ToDo: добвить проверку наargument out of range
            
            //Console.WriteLine("Цвет текста");
            //Console.ResetColor();

            if(command == "create")
            {
                Console.WriteLine("как назовём засранца?");
                var name = Console.ReadLine();
                var todo = new Todo(name); //ToDO: проверка на пустой ввод и на неуникальное имя
                repository.Create(todo);
                Console.WriteLine($"да прибудет с нами новый тудус: {todo.Name}...");
                repository.UpdateFile();
                
            }
            else if(command == "wip")
            {
                Console.WriteLine("какой тудус?");
                int.TryParse(Console.ReadLine(), out var currentId); 
                repository.ToInProgressFromNew(currentId);
                repository.UpdateFile();
            }
            else if(command == "done")
            {
                Console.WriteLine("какой тудус?");
                int.TryParse(Console.ReadLine(), out var currentId); 
                repository.Done(currentId);
                repository.UpdateFile();
            }
            else if(command == "return")
            {
                Console.WriteLine("какой тудус?");
                int.TryParse(Console.ReadLine(), out var currentId); 
                repository.ToInProgressFromDone(currentId);
                repository.UpdateFile();
            }
            else if(command == "reopen")
            {
                Console.WriteLine("какой тудус?");
                int.TryParse(Console.ReadLine(), out var currentId); 
                repository.ReOpen(currentId);
                repository.UpdateFile();
            }
            else if(command == "burn")
            {
                Console.WriteLine("чей настал черёд?");
                int.TryParse(Console.ReadLine(), out var currentId);
                repository.Burn(currentId); //ToDo: пересчитать id или взять из параллельного списка и смапить
                                                                                // ToDo: добавить обработку нуллового id
                Console.WriteLine("прощай, брат...");
                repository.UpdateFile();
            }
            else if(command == "edit")
            {
                Console.WriteLine("время переименовать тудус");
                Console.WriteLine("чей настал черёд?");
                int.TryParse(Console.ReadLine(), out var currentId); 
                //var name = Console.ReadLine();
                Console.WriteLine("как его теперь назовём??");
                var editedName = Console.ReadLine();
                // обратиться к тудусу и сделать set нового имени?
                repository.Edit(currentId, editedName); // ToDo: добавить обработку нуллового id
                //ToDo: добвить проверку наargument out of range
                repository.UpdateFile();
            }
            else if(command == "all") // ToDo: проверка на пустоту
            {
                //Console.WriteLine(repository.All());
                foreach (Todo todo in repository.All())
                {
                    if (todo.Status != State.Completed)
                    {
                        Console.WriteLine(todo);
                    }
                }
                Console.WriteLine("тудусов много не бывает...");
            }
            else if(command == "search") 
            {
               Console.WriteLine("какой тудус ищем?");
               string searchName = Console.ReadLine(); 
               repository.Search(searchName);
            }
            else if(command == "filter") 
            {
                Console.WriteLine($"Существуют следующие статусы: {State.New}, {State.InProgress}, {State.Completed}");
                Console.WriteLine("на какой статус смотрим?");
                State.TryParse<State>(Console.ReadLine(), out var filterState); 
                repository.Filter(filterState);
            }
            else if(command == "get")
            {
                Console.WriteLine("чей настал черёд?");
                int.TryParse(Console.ReadLine(), out var currentId);
                var currentTodo = repository.Get(currentId);
                if (currentTodo == null)
                {
                    Console.WriteLine("ну ты и дурачок, конечно");
                }
                else
                {
                    Console.WriteLine(currentTodo);
                }
            }
            else if(command == "save")
            {
                repository.Save();
            }
            else if(command == "export")
            {
                repository.Export();
            }
            else if(command == "import")
            {
                Console.WriteLine("укажи путь к файлу для загрузки");
                string path = Console.ReadLine(); 
                repository.Import(path);
                Console.WriteLine("ура! тудусы из файла загружены!");
            }
            else if(command == "f")
            {
                Console.WriteLine("R.I.P.");
                break;
            }
            else if(command?.Equals(Operation.Help.ToString(), StringComparison.InvariantCultureIgnoreCase)??false)
            {
                Console.WriteLine(@"
                help - просмотреть список команд
                import - загрузить тудусы из файла
                create - создать тудус
                to in progress - толнуть новый тудус в работу
                done - завершить тудус
                return to in progress - вернуть завершённый тудус в работу
                reopen - переоткрыть тудус
                burn - стереть тудус с лица земли
                edit - изменить тудус
                all - просмотреть все тудусы
                get - просмотреть конкретный тудус
                save - записать тудусы в файл 
                export - скачать тудусы как пдф
                f - покинуть матрицу
                ");
            }
            else
            {
                Console.WriteLine("я не понимаю тебя, брат...");
            }
        } */
    }
}

enum Operation
{
    Help = 0,
    Create = 1,
    Get = 2,
    Edit = 3,
    Burn = 4,
    All = 5,
    F = 6,
}