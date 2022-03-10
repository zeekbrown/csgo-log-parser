using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class PlayerSwitchedTeamEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string player = @"""([^""]*)""";
    private const string team = @"<([^>]*)>";
    private static readonly Regex regex = new($"^L {stamp}: {player} switched from team {team} to {team}$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp   = groups[1].ToDateTime(),
            Player  = groups[2].Value,
            OldTeam = groups[3].Value,
            NewTeam = groups[4].Value,
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Player { get; set; }
        public string OldTeam { get; set; }
        public string NewTeam { get; set; }
    }
}