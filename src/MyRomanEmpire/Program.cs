using MyRomanEmpire.Models;

namespace MyRomanEmpire;

public class Program
{
    private readonly List<Todo> _todos = new List<Todo>();
    
    public static void Main(string[] args)
    {
        Console.WriteLine("тудусы приветствуют тебя...");
        Console.WriteLine("если нужна помощь, скажи help...");
        int id = 0;

        while (true)
        {
            Console.WriteLine("как поступим с очередным тудусом?....");
            var command = System.Console.ReadLine();

            if(command == "create")
            {
                // делай добавление
                Console.WriteLine("как назовём засранца?");
                var name = Console.ReadLine();
                var todo = new Todo(id, name); //ToDO: проверка на пустой ввод и на неуникальное имя
                id += 1;
                Console.WriteLine($"да прибудет с нами новый тудус: {id} {name}...");
                _todos.Add(todo);
            }
            else if(command == "burn")
            {
                Console.WriteLine("чей настал черёд?");
                var input = Console.ReadLine();
                _todos.Remove(_todos.Single(x => x.Name == input));
                Console.WriteLine("прощай, брат...");
            }
            else if(command == "edit")
            {
                Console.WriteLine("время переименовать тудус");
                Console.WriteLine("чей настал черёд?");
                //var id = Console.ReadLine();
                var name = Console.ReadLine();
                Console.WriteLine("как его теперь назовём??");
                var new_name = Console.ReadLine();
                // обратиться к тудусу и сделать set нового имени?
                _todos.Single(x => x.Name == name).Name = new_name.ToString();
            }
            else if(command == "all")
            {
                foreach (var todo in _todos)
                    Console.WriteLine(todo);
                Console.WriteLine("тудусов много не бывает...");
            }
            else if(command == "get")
            {
                Console.WriteLine("чей настал черёд?");
                var id = Console.ReadLine();
                // обратиться к тудусу, сделать get его имени и вывести
            }
            else if(command == "f")
            {
                break;
            }
            else if(command == "help")
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