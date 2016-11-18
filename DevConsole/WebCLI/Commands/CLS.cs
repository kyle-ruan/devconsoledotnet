
using System;

namespace DevConsole.WebCLI.Commands
{
    [ConsoleCommand("cls","Clears the console")]
    public class CLS:IConsoleCommand
    {
        public ConsoleResult Run(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}