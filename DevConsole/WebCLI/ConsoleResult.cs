namespace DevConsole
{
    public class ConsoleResult
    {
        private string _output = "";
        private bool _isError = false;
        private bool _isHtml = false;

        public string output
        {
            get { return _output; }
            set { _output = value; }
        }

        public bool isError
        {
            get { return _isError; }
            set { _isError = value; }
        }

        public bool isHTML
        {
            get { return _isHtml; }
            set { _isHtml = value; }
        }

        public ConsoleResult()
        {
            
        }

        public ConsoleResult(string output)
        {
            this.output = output;
        }
    }

    
    public class ConsoleErrorResult : ConsoleResult
    {
        public ConsoleErrorResult()
        {
            isError = true;
            output = "Invalid syntax";
        }

        public ConsoleErrorResult(string output)
        {
            isError = true;
            this.output = output;
        }
    }
}