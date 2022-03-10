using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class GameOverEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string game = @"(\w+)";
    private const string map = @"(\w+)";
    private const string score = @"(\d+:\d+)";
    private const string duration = @"(\d+)";
    private static readonly Regex regex = new($"^L {stamp}: Game Over: {game} {game} {map} score {score} after {duration} min$");
    // TODO: update {game} and {game} to something like game and mode once I figure out which is which

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp    = groups[1].ToDateTime(),
            Game1    = groups[2].Value,
            Game2    = groups[3].Value,
            Map      = groups[4].Value,
            Score    = groups[5].Value,
            Duration = groups[6].ToInt32(),
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Game1 { get; set; }
        public string Game2 { get; set; }
        public string Map { get; set; }
        public string Score { get; set; }
        public int Duration { get; set; }
    }
}