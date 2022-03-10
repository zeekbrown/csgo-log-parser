using System;
using System.Text.RegularExpressions;

namespace CounterStrike.GameEvents;

public static class PlayerAttackedPlayerEvent
{
    private const string stamp = @"(\d\d/\d\d/\d\d\d\d - \d\d:\d\d:\d\d)";
    private const string player = @"""([^""]*)"" \[[^]]*\]";
    private const string weapon = @"""([^""]*)""";
    private const string damage = @"\(damage ""(\d*)""\)";
    private const string damageArmor = @"\(damage_armor ""(\d*)""\)";
    private const string hitgroup = @"\(hitgroup ""([^""]*)""\)";
    private static readonly Regex regex = new($"^L {stamp}: {player} attacked {player} with {weapon} {damage} {damageArmor} \\(health \"\\d*\"\\) \\(armor \"\\d*\"\\) {hitgroup}$");

    public static bool IsMatch(string line) => regex.IsMatch(line);

    public static Data GetData(string line)
    {
        var groups = regex.Match(line).Groups;

        return new Data
        {
            Stamp    = groups[1].ToDateTime(),
            Player   = groups[2].Value,
            Victim   = groups[3].Value,
            Weapon   = groups[4].Value,
            Damage   = groups[5].ToInt32(),
            Armor    = groups[6].ToInt32(),
            Hitgroup = groups[7].Value,
        };
    }

    public record Data
    {
        public DateTime Stamp { get; set; }
        public string Player { get; set; }
        public string Victim { get; set; }
        public string Weapon { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public string Hitgroup { get; set; }
    }
}