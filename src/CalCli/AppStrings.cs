namespace CalCli
{
    public partial class App
    {
        private string unknownArgsSeparator = ", ";
        private string HelpMessage => @"
Cli Calculator
Maths in the terminal

Usage: CliCalc expression [options]

expression:
Any valid math expression

options:
-h | --help             Shows this message
-d | --diagnostics      Outputs diagnostic data during computation
-v | --version          Displays the current version
";

        private string VersionMessage => @"
Cli Calculator
Version: 0.1
";

        private string ShowUnknownArgumentsHelpMessage(string[] unknownArgs) =>
            string.Format(
                "Unknown {0}: {1}\nTry CliCalc --help\n",
                unknownArgs.Length == 1 ? "option" : "options",
                string.Join(unknownArgsSeparator, unknownArgs)
            );
    }
}
