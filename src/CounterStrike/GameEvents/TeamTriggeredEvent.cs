using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class TeamTriggeredEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string team = @"""([^""]*)""";
    private const string gameEvent = @"""([^""]*)""";
    private static readonly Regex regex = new($"^L {stamp}: Team {team} triggered {gameEvent} \\(CT \"\\d*\"\\) \\(T \"\\d*\"\\)$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp = groups[1].ToDateTime(),
            Team  = groups[2].Value,
            Event = groups[3].Value,
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Team { get; set; }
        public string Event { get; set; }
    }
}