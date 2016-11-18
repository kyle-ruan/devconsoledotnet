
using System.Threading;

namespace DevConsole.WebCLI.Commands
{
    [ConsoleCommand("echo","Echos back the first arg received")]
    public class Echo:IConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            Thread.Sleep(6000);
            if (args.Length > 1)
            {
                return new ConsoleResult(args[1]);
            }

            return new ConsoleResult();
        }
    }
}