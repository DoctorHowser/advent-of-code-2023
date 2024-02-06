using System.Diagnostics;
using System.Text.RegularExpressions;
using advent_of_code_2023.Interfaces;
namespace advent_of_code_2023;

public partial class NumberSearch : ISolve
{

    [GeneratedRegex("\\d|one|two|three|four|five|six|seven|eight|nine")]
    private static partial Regex DigitStringRegexLeft();

    [GeneratedRegex("\\d|one|two|three|four|five|six|seven|eight|nine", RegexOptions.RightToLeft)]
    private  static partial Regex DigitStringRegexRight();

    public (string, string) Solve (string input)
    {

        // part1 find first match, last match
        string first = input.First( item => char.IsNumber(item) ).ToString();
        string last = input.Last(item => char.IsNumber(item)).ToString();

        string solve1 = first + last;

        // part2 find first match, last match, parse
                var firstReg = DigitStringRegexLeft();
                var lastReg = DigitStringRegexRight();


        string first2 = firstReg.Match(input).ToString();
        string last2 = lastReg.Match(input).ToString();

        first2 = TranslateLangToNum(first2);
        last2 = TranslateLangToNum(last2);

        string solve2 = first2 + last2;


        return (solve1, solve2);

    }

   // map characters to digits, if required
    private static string TranslateLangToNum (string input) {

            if(char.IsDigit(input[0])) {
                return input;
            } else {
                
               return input switch  {
                     "one" => "1",
                    "two" => "2",
                    "three" => "3",
                    "four" => "4",
                    "five" => "5",
                    "six" => "6",
                    "seven" => "7",
                    "eight" => "8",
                    "nine" => "9",
                    _ => throw new UnreachableException($"Translation Failed with: {input}"),
                };
            }
    
    }
}