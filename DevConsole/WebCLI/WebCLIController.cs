using DevConsole.WebCLI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace DevConsole
{
    public class WebCLIController : ApiController
    {
        public static readonly Type AttributeType = typeof (ConsoleCommandAttribute);
        public static readonly List<Type> CommandTypes;

        static WebCLIController()
        {
            var type = typeof (IConsoleCommand);
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(asm => asm.GetTypes());

            CommandTypes = types.Where(t => t.GetInterfaces().Contains(type)).ToList();
        }

        // POST: api/webcli
        public ConsoleResult Post([FromBody] CommandInput command)
        {
            var args = command.GetArgs();

            var cmd = args.First().ToUpper();

            Type cmdTypeToRun = null;

            foreach (var cmdType in CommandTypes)
            {
                var attr = (ConsoleCommandAttribute) cmdType.GetTypeInfo().GetCustomAttributes(AttributeType).First();

                if (attr != null && attr.Name.ToUpper() == cmd)
                {
                    cmdTypeToRun = cmdType;
                    break;
                }
            }

            if (cmdTypeToRun == null)
            {
                return new ConsoleErrorResult();
            }
            try
            {
                var cmdObj = Activator.CreateInstance(cmdTypeToRun) as IConsoleCommand;

                return cmdObj.Run(args);
            }
            catch 
            {
                
                return new ConsoleErrorResult();
            }
        }
    }

}
