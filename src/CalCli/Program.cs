using System;
using System.Linq;
using CalCli.CalculatorParser;


namespace CalCli
{
    // TODO: Convert to do items to issues
    // TODO: Consider logging.
    // TODO: Consider async.
    // TODO: Add verbose and/or debug logging
    class Program
    {
        static void Main(string[] args)
        {
            var (appArgs, app) = Bootstrap(args);
            app.Invoke(appArgs);
        }

        static (AppCommandLineArgs, App) Bootstrap(string[] args)
        {
            var tokeniser = new Tokeniser();
            var parser = new Parser();
            var appArgs = new AppCommandLineParser().Parse(args);
            var app = new App(parser, tokeniser);

            return (appArgs, app);
        }
    }
}
