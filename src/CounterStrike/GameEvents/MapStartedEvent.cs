using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class MapStartedEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string map = @"""([^""]*)""";
    private static readonly Regex regex = new($"^L {stamp}: Started map {map} \\(CRC \"-?\\d+\"\\)$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp = groups[1].ToDateTime(),
            Map   = groups[2].Value,
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Map { get; set; }
    }
}