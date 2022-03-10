using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class TeamScoredEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string team = @"""([^""]*)""";
    private const string value = @"""([^""]*)""";

    private static readonly Regex regex = new($"^L {stamp}: Team {team} scored {value} with {value} players$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp   = groups[1].ToDateTime(),
            Team    = groups[2].Value,
            Score   = groups[3].ToInt32(),
            Players = groups[4].ToInt32(),
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Team { get; set; }
        public int Score { get; set; }
        public int Players { get; set; }
    }
}