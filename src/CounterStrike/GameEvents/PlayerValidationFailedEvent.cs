using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class PlayerValidationFailedEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string client    = @"(.+?)";
    private const string code      = @"(\d+)";
    private static readonly Regex regex = new($"^L {stamp}: STEAMAUTH: Client {client} received failure code {code}$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp     = groups[1].ToDateTime(),
            Player    = groups[2].Value,
            ErrorCode = groups[3].ToInt32(),
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Player { get; set; }
        public int ErrorCode { get; set; }
    }
}