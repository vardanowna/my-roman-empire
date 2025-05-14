using MyRomanEmpire.Models;
using MyRomanEmpire.Repositories;

namespace MyRomanEmpire;

public class Program // слой представления
{
    private static readonly TodoRepository repository = new TodoRepository();
    
    public static void Main(string[] args)
    {
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
                Console.WriteLine($"да прибудет с нами новый тудус: {todo.Id} {todo.Name}...");
                
            }
            else if(command == "mark")
            {
                Console.WriteLine("тудус свершился!");
                Console.WriteLine("а какой?");
                int.TryParse(Console.ReadLine(), out var currentId); 
                repository.Done(currentId);
            }
            else if(command == "unmark")
            {
                Console.WriteLine("тудус не свершился!");
                Console.WriteLine("а какой?");
                int.TryParse(Console.ReadLine(), out var currentId); 
                repository.Undone(currentId);
            }
            else if(command == "burn")
            {
                Console.WriteLine("чей настал черёд?");
                int.TryParse(Console.ReadLine(), out var currentId);
                repository.Burn(currentId); //ToDo: пересчитать id или взять из параллельного списка и смапить
                                                                                // ToDo: добавить обработку нуллового id
                Console.WriteLine("прощай, брат...");
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
            else if(command == "f")
            {
                Console.WriteLine("R.I.P.");
                break;
            }
            else if(command?.Equals(Operation.Help.ToString(), StringComparison.InvariantCultureIgnoreCase)??false)
            {
                Console.WriteLine(@"
                help - просмотреть список команд
                create - создать тудус
                mark - отметить сделанным
                unmark - отметить несделанным
                burn - стереть тудус с лица земли
                edit - изменить тудус
                all - просмотреть все тудусы
                get - просмотреть конкретный тудус
                f - покинуть матрицу
                ");
            }
            else
            {
                Console.WriteLine("я не понимаю тебя, брат...");
            }
        }
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