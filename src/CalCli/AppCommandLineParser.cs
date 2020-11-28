using System;
using System.Collections.Generic;


namespace CalCli
{
    /// <summary>
    /// Extracts args
    /// </summary>
    public class AppCommandLineParser
    {
        public AppCommandLineArgs Parse(string[] args)
        {
            string expression = "";
            bool OptionEncountered = false;
            bool showHelp = args.Length == 0;
            bool showVersion = false;
            bool enableDiagnostics = false;
            var unknownArgs = new List<string>();

            foreach(var arg in args)
            {
                if(arg.StartsWith("-") || arg.StartsWith("--"))
                    OptionEncountered = true;

                if(OptionEncountered)
                {
                    switch(arg)
                    {
                        case "-h":
                        case "--help":
                            showHelp = true;
                            break;

                        case "-v":
                        case "--version":
                            showVersion = true;
                            break;

                        case "-d":
                        case "--diagnostics":
                            enableDiagnostics = true;
                            break;

                        default:
                            unknownArgs.Add(arg);
                            break;
                    }
                }
                else
                {
                    expression += arg;
                }
            }


            return new AppCommandLineArgs(
                ShowHelp: showHelp,
                ShowVersion: showVersion,
                EnableDiagnostics: enableDiagnostics,
                Expression: expression,
                UnknownArguments: unknownArgs.ToArray()
            );
        }
    }
}
