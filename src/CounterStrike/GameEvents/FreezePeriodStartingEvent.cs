using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class FreezePeriodStartingEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private static readonly Regex regex = new($"^L {stamp}: Starting Freeze period$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp = groups[1].ToDateTime(),
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
    }
}