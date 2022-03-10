using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class GameObjectSpawnedEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string gameObject = @"(.+?)";
    private static readonly Regex regex = new($"^L {stamp}: {gameObject} spawned at -?\\d+\\.\\d+ -?\\d+\\.\\d+ -?\\d+\\.\\d+, velocity -?\\d+\\.\\d+ -?\\d+\\.\\d+ -?\\d+\\.\\d+$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp      = groups[1].ToDateTime(),
            GameObject = groups[2].Value,
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string GameObject { get; set; }
    }
}