using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class ServerMessageEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string message = @"""([^""]*)""";
    private static readonly Regex regex = new($"^L {stamp}: server_message: {message}$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp   = groups[1].ToDateTime(),
            Message = groups[2].Value,
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Message { get; set; }
    }
}