using System.Linq;
using System.Text.RegularExpressions;

namespace DevConsole
{
    public class CommandInput
    {
        public string CmdLine { get; set; }

        public string[] GetArgs()
        {
            var tokenEx = new Regex(@"[^\s""]+|""[^""]*""");

            return tokenEx.Matches(CmdLine)
                .Cast<Match>()
                .Select(s => s.Value.Replace("\"", ""))
                .ToArray();
        }
    }
}