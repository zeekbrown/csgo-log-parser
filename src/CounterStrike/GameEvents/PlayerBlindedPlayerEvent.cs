using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class PlayerBlindedPlayerEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string player = @"""([^""]*)""";
    private const string duration = @"(\d+\.\d+)";
    private static readonly Regex regex = new($"^L {stamp}: {player} blinded for {duration} by {player} from flashbang entindex \\d+ $");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp    = groups[1].ToDateTime(),
            Player   = groups[4].Value,
            Victim   = groups[2].Value,
            Duration = groups[3].ToDouble(),
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Player { get; set; }
        public string Victim { get; set; }
        public double Duration { get; set; }
    }
}