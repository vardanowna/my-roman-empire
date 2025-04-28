using MyRomanEmpire.Models;

namespace MyRomanEmpire;

public class Program
{
    private readonly List<Todo> _todos = new List<Todo>();
    
    public static void Main(string[] args)
    {
        System.Console.WriteLine("тудусы приветствуют тебя...");
        int id = 0;

        while (true)
        {
            System.Console.WriteLine("как поступим с очередным тудусом?....");
            var command = System.Console.ReadLine();

            if(command == "new")
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
                var id = Console.ReadLine();
                _todos.RemoveAt(id);
                Console.WriteLine("прощай, брат...");
            }
            else if(command == "edit")
            {
                Console.WriteLine("время переименовать тудус");
                Console.WriteLine("чей настал черёд?");
                var id = Console.ReadLine();
                var name = Console.ReadLine();
                // обратиться к тудусу и сделать set нового имени?
                Console.WriteLine("прощай, брат...");
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
            else
            {
                Console.WriteLine("я не понимаю тебя, брат...");
            }
        }
    }
}

