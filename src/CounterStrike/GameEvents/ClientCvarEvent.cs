using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class ClientCvarEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string value = @"""([^""]*)""";
    private static readonly Regex regex = new($"^L {stamp}: {value} = {value}$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp = groups[1].ToDateTime(),
            Name  = groups[2].Value,
            Value = groups[3].Value,
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}