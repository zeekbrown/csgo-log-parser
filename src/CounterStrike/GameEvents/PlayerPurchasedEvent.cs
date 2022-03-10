using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class PlayerPurchasedEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string player = @"""([^""]*)""";
    private const string weapon = @"""([^""]*)""";
    private static readonly Regex regex = new($"^L {stamp}: {player} purchased {weapon}$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp  = groups[1].ToDateTime(),
            Player = groups[2].Value,
            Weapon = groups[3].Value,
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Player { get; set; }
        public string Weapon { get; set; }
    }
}