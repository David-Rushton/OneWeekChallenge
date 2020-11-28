namespace CalCli
{
    public record AppCommandLineArgs(
        bool ShowHelp,
        bool ShowVersion,
        bool EnableDiagnostics,
        string Expression,
        string[] UnknownArguments
    );
}
