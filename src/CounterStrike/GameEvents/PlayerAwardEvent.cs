using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class PlayerAwardEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string award = @"{([^}]*)}";
    private const string player = @"([^,]*)";
    private const string value = @"(\d+\.\d+)";
    private const string position = @"(\d+)";
    private static readonly Regex regex = new($"^L {stamp}: ACCOLADE, FINAL: {award},\\t{player},\tVALUE: {value},\tPOS: {position},\tSCORE: {value}$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp    = groups[1].ToDateTime(),
            Award    = groups[2].Value,
            Player   = groups[3].Value,
            Value    = groups[4].ToDouble(),
            Position = groups[5].ToInt32(),
            Score    = groups[6].ToDouble(),
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Award { get; set; }
        public string Player { get; set; }
        public double Value { get; set; }
        public int Position { get; set; }
        public double Score { get; set; }
    }
}