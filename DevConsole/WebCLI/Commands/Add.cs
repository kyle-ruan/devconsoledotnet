
namespace DevConsole.WebCLI.Commands
{
    [ConsoleCommand("add","Add 2 numbers together")]
    public class Add:IConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            double x = double.Parse(args[1]);
            double y = double.Parse(args[2]);

            return new ConsoleResult((x + y).ToString());
        }
    }
}