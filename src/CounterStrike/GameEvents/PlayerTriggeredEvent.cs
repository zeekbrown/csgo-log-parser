using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class PlayerTriggeredEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string player = @"""([^""]*)""";
    private const string gameEvent = @"""([^""]*)""";
    private const string location = @"(?: at (bombsite [AB]))?";
    private static readonly Regex regex = new($"^L {stamp}: {player} triggered {gameEvent}{location}$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp    = groups[1].ToDateTime(),
            Player   = groups[2].Value,
            Event    = groups[3].Value,
            Location = groups[4].Value,
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Player { get; set; }
        public string Event { get; set; }
        public string Location { get; set; }
    }
}