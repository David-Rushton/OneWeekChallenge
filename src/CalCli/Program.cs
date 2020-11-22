using System;
using System.Linq;


namespace CalCli
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Contains("-h") || args.Contains("--help"))
            {
                ShowHelp();
                Environment.Exit(0);
            }

            if(args.Contains("-v") || args.Contains("--version"))
            {
                ShowHelp();
                Environment.Exit(0);
            }

            var tokens = Bootstrap().Invoke(args);
            foreach(var token in tokens)
            {
                Console.WriteLine(token);
            }
        }

        static Tokeniser Bootstrap()
            => new Tokeniser();

        static void ShowHelp() => Console.WriteLine(
@"
A CLI Calculator
Usage: CalcCli Expression [Args]

Expression:
# returns 2
CalcCli 1+1

Args:
-v --version    Show version number
-h --help       Show this message
");

        static void ShowVersion() => Console.WriteLine("v0.1");
    }
}
