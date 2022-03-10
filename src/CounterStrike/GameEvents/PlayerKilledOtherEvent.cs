using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class PlayerKilledOtherEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string player = @"""([^""]*)"" \[[^]]*\]";
    private const string weapon = @"""([^""]*)""";
    private const string modifier = @"(?: \(([^)]*)\))?";
    private static readonly Regex regex = new($"^L {stamp}: {player} killed other {player} with {weapon}{modifier}$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp    = groups[1].ToDateTime(),
            Player   = groups[2].Value,
            Victim   = groups[3].Value,
            Weapon   = groups[4].Value,
            Modifier = groups[5].Value,
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Player { get; set; }
        public string Victim { get; set; }
        public string Weapon { get; set; }
        public string Modifier { get; set; }
    }
}