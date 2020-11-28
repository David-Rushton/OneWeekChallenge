using System;
using CalCli.CalculatorParser;


namespace CalCli
{
    public partial class App
    {
        readonly Parser _parser;
        readonly Tokeniser _tokeniser;


        public App(Parser parser, Tokeniser tokeniser) => (_parser, _tokeniser) = (parser, tokeniser);


        public void Invoke(AppCommandLineArgs args)
        {
            if(args.EnableDiagnostics)
                Console.WriteLine($"Config: {args}");

            if(args.UnknownArguments.Length > 0)
                ShowUnknownArgumentsHelpAndExit(args);

            if(args.ShowHelp)
                ShowHelpAndExit();

            if(args.ShowVersion)
                ShowVersion();


            _parser.Invoke(_tokeniser.Invoke(args.Expression));
        }


        private void ShowHelpAndExit()
        {
            Console.WriteLine(HelpMessage);
            Environment.Exit(0);
        }

        private void ShowUnknownArgumentsHelpAndExit(AppCommandLineArgs args)
        {
            Console.WriteLine(ShowUnknownArgumentsHelpMessage(args.UnknownArguments));
            Environment.Exit(1);
        }

        private void ShowVersion() => Console.WriteLine(VersionMessage);
    }
}
