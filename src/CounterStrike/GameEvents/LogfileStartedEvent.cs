using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class LogfileStartedEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string file = @"\(file ""([^""]*)""\)";
    private const string game = @"\(game ""([^""]*)""\)";
    private const string version = @"\(version ""(\d+)""\)";
    private static readonly Regex regex = new($"^L {stamp}: Log file started {file} {game} {version}$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp   = groups[1].ToDateTime(),
            File    = groups[2].Value,
            Game    = groups[3].Value,
            Version = groups[4].ToInt32(),
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string File { get; set; }
        public string Game { get; set; }
        public int Version { get; set; }
    }
}