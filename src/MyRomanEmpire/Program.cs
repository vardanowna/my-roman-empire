using MyRomanEmpire.Models;

namespace MyRomanEmpire;

public class Program
{
    private static readonly List<Todo> _todos = new List<Todo>();
    
    public static void Main(string[] args)
    {
        // var ToDoOne = new Todo(1, "one");
        // ToDoOne.DoSMTH(); // non-static
        // Todo.AnothertDoSMTH(); // static
        
        Console.WriteLine("тудусы приветствуют тебя...");
        Console.WriteLine("если нужна помощь, скажи help...");
        int id = 0;

        while (true)
        {
            Console.WriteLine("что дальше?....");
            var command = System.Console.ReadLine();

            if(command == "create")
            {
                // делай добавление
                Console.WriteLine("как назовём засранца?");
                var name = Console.ReadLine();
                var todo = new Todo(id, name); //ToDO: проверка на пустой ввод и на неуникальное имя
                Console.WriteLine($"да прибудет с нами новый тудус: {id} {name}...");
                _todos.Add(todo);
                id += 1;
            }
            else if(command == "burn")
            {
                Console.WriteLine("чей настал черёд?");
                int.TryParse(Console.ReadLine(), out var currentId);
                _todos.Remove(_todos.Single(x => x.Id == currentId)); //ToDo: пересчитать id или взять из параллельного списка и смапить
                Console.WriteLine("прощай, брат...");
            }
            else if(command == "edit")
            {
                Console.WriteLine("время переименовать тудус");
                Console.WriteLine("чей настал черёд?");
                int.TryParse(Console.ReadLine(), out var currentId);
                //var name = Console.ReadLine();
                Console.WriteLine("как его теперь назовём??");
                var new_name = Console.ReadLine();
                // обратиться к тудусу и сделать set нового имени?
                _todos.Single(x => x.Id == currentId).Name = new_name.ToString();
            }
            else if(command == "all") // ToDo: проверка на пустоту
            {
                foreach (var todo in _todos)
                    Console.WriteLine(todo);
                Console.WriteLine("тудусов много не бывает...");
            }
            else if(command == "get")
            {
                Console.WriteLine("чей настал черёд?");
                int.TryParse(Console.ReadLine(), out var currentId);
                Console.WriteLine(_todos.Single(x => x.Id == currentId));
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