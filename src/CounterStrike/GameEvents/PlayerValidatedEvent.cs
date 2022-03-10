using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class PlayerValidatedEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string player = @"""([^""]*)""";
    private static readonly Regex regex = new($"^L {stamp}: {player} STEAM USERID validated$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp  = groups[1].ToDateTime(),
            Player = groups[2].Value,
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Player { get; set; }
    }
}