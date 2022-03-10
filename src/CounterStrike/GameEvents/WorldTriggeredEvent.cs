using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class WorldTriggeredEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string gameEvent = @"""([^""]*)""";
    private const string map = @"(?: on ""([^""]*)""| \(CT ""\d*""\) \(T ""\d*""\))?";
    private static readonly Regex regex = new($"^L {stamp}: World triggered {gameEvent}{map}$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp = groups[1].ToDateTime(),
            Event = groups[2].Value,
            Map   = groups[3].Value,
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Event { get; set; }
        public string Map { get; set; }
    }
}