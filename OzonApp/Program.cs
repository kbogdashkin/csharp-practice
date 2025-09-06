namespace OzonApp;

class Program
{
    private static string? name;
    private static string COMMANDS = "/start, /help, /info, /exit";

    static void Main(string[] args)
    {
        Console.WriteLine("Добрый день!");
        Console.WriteLine($"Список доступных команд: {COMMANDS}");

        string? input = "";

        do
        {
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            if (input == "/start")
            {
                StartCommand();
            }
            else if (input == "/help")
            {
                HelpCommand();
            }
            else if (input == "/info")
            {
                InfoCommand();
            }
            else if (input.StartsWith("/echo"))
            {
                EchoCommand(input);
            }
            else
            {
                Console.WriteLine("Неизвестная команда");
            }
        } while (input != "/exit");
    }

    static bool Greeting(string str = "")
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine($"Добрый день, {name}");
            return true;
        }

        Console.WriteLine($"Введите имя, {str}");
        return false;
    }

    static void StartCommand()
    {
        if (Greeting())
        {
            return;
        }

        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Имя не может быть пустым");
            return;
        }

        name = input;
        Console.WriteLine($"Добрый день, {name}");

        COMMANDS = COMMANDS.Insert(22, "/echo, ");
    }

    static void HelpCommand()
    {
        if (Greeting("с помощью команды /start"))
        {
            Console.WriteLine($"Для того чтобы пользоваться программой, вам надо ввести одну из команд {COMMANDS}");
        }
    }

    static void InfoCommand()
    {
        if (Greeting("с помощью команды /start"))
        {
            Console.WriteLine("Версия программы 1.0. Дата сборки 28.08.2025");
        }
    }

    static void EchoCommand(string str)
    {
        if (Greeting("с помощью команды /start"))
        {
            var echo = str.Split(" ");

            if (echo.Length != 2)
            {
                return;
            }

            Console.WriteLine(echo[1]);
        }
    }
}