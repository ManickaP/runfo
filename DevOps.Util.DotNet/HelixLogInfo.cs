using System;
using System.Collections.Generic;

namespace DevOps.Util.DotNet
{
    public enum HelixLogKind
    {
        RunClient,

        Console,

        CoreDump,

        TestResults
    }

    public sealed class HelixLogInfo
    {
        public static readonly HelixLogInfo Empty = new HelixLogInfo(null, null, null, null);

        public string? RunClientUri { get; }

        public string? ConsoleUri { get; }

        public string? CoreDumpUri { get; }

        public string? TestResultsUri { get; }

        public HelixLogInfo(
            string? runClientUri,
            string? consoleUri,
            string? coreDumpUri,
            string? testResultsUri)
        {
            RunClientUri = runClientUri;
            ConsoleUri = consoleUri;
            CoreDumpUri = coreDumpUri;
            TestResultsUri = testResultsUri;
        }

        public IEnumerable<(HelixLogKind kind, string Uri)> GetUris()
        {
            foreach (object? value in Enum.GetValues(typeof(HelixLogKind)))
            {
                if (value is HelixLogKind kind)
                {
                    var uri = GetUri(kind);
                    if (uri is object)
                    {
                        yield return(kind, uri);
                    }
                }
            }
        }

        public string? GetUri(HelixLogKind kind) => kind switch
        {
            HelixLogKind.RunClient => RunClientUri,
            HelixLogKind.Console => ConsoleUri,
            HelixLogKind.CoreDump => CoreDumpUri,
            HelixLogKind.TestResults => TestResultsUri,
            _ => throw new InvalidOperationException($"Invalid enum value {kind}")
        };
    }

}