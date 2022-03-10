using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class PlayerDisconnectedEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string player = @"""([^""]*)""";
    private const string reason = @"\(reason ""([^""]*)""\)";
    private static readonly Regex regex = new($"^L {stamp}: {player} disconnected {reason}$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp = groups[1].ToDateTime(),
            Player = groups[2].Value,
            Reason = groups[3].Value,
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Player { get; set; }
        public string Reason { get; set; }
    }
}