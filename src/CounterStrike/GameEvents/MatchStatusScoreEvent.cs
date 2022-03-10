using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class MatchStatusScoreEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string score = @"(\d+:\d+)";
    private const string map = @"""([^""]*)""";
    private const string rounds = @"(-?\d+)";
    private static readonly Regex regex = new($"^L {stamp}: MatchStatus: Score: {score} on map {map} RoundsPlayed: {rounds}$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp  = groups[1].ToDateTime(),
            Score  = groups[2].Value,
            Map    = groups[3].Value,
            Rounds = groups[4].ToInt32(),
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Score { get; set; }
        public string Map { get; set; }
        public int Rounds { get; set; }
    }
}