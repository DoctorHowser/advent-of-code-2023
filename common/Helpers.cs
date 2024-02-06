namespace advent_of_code_2023.Utilities;
using System.Text.RegularExpressions;

public  static partial class Helpers {
    [GeneratedRegex("\\d")]
    public static partial Regex DigitRegex();

    [GeneratedRegex("(\\d)+")]
    public static partial Regex NumberRegex();
}

