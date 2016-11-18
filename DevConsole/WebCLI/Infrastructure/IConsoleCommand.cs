
namespace DevConsole.WebCLI.Commands
{
    public interface IConsoleCommand
    {
        ConsoleResult Run(string[] args);
    }
}
