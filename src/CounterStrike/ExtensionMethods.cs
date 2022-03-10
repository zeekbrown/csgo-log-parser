using System;
using System.Text.RegularExpressions;

namespace CounterStrike;

public static class ExtensionMethods
{
    public static DateTime ToDateTime(this Group group) => DateTime.Parse(group.Value.Replace(" - ", " "));
    public static double ToDouble(this Group group) => double.Parse(group.Value);
    public static int ToInt32(this Group group) => int.Parse(group.Value);
    public static string ToSteamID(this string player) => Regex.Replace(player, "^([^<]+)<([^>]+)><([^>]+)><([^>]+)>$", "$3");
    public static string ToPlayerName(this string player) => Regex.Replace(player, "^([^<]+)<([^>]+)><([^>]+)><([^>]+)>$", "$1");
}