namespace OzonApp;

class Program
{
    private static string? name;
    private const string COMMANDS = "/start, /help, /info, /exit";

    static void Main(string[] args)
    {
        Console.WriteLine("Добрый день!");
        Console.WriteLine($"Список доступных команд: {COMMANDS}");

        string? input = "";

        while (input != "/exit")
        {
            input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                
            } else if (input == "/start")
            {
                StartCommand();
            } else if (input == "/help")
            {
                HelpCommand();
            } else if (input == "/info")
            {
                InfoCommand();
            } else if (input.StartsWith("/echo"))
            {
                EchoCommand(input);
            }
            else
            {
                Console.WriteLine("Неизвестная команда");
            }
        }
    }

    static void Greeting()
    {
        if (name != null)
        {
            Console.WriteLine($"Добрый день, {name}");
        }
        
    }

    static void StartCommand()
    {
        Console.WriteLine("Введите имя");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Имя не может быть пустым");
            return;
        }

        name = input;
        Greeting();
    }
    
    static void HelpCommand()
    {
        Greeting();
        Console.WriteLine($"Для того чтобы пользоваться программой, вам надо ввести одну из команд {COMMANDS}");
    }

    static void InfoCommand()
    {
        Greeting();
        Console.WriteLine("Версия программы 1.0. Дата сборки 28.08.2025");
    }

    static void EchoCommand(string input)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Воспользуйтесь командой /start для ввода имени");
            return;
        }
        
        Greeting();

        var text = input.Substring(5).Trim();

        if (!string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine(text);
        }
    }
}