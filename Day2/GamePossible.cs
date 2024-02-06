using advent_of_code_2023.Interfaces;
using advent_of_code_2023.Utilities;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace advent_of_code_2023;

public class CubeGame
{

    readonly Regex DigitRegex = Helpers.NumberRegex();

    public string gameRound;
    public int mostRed;
    public int mostGreen;
    public int mostBlue;

    public bool IsPossible = false;

    public CubeGame(string input)
    {
        Dictionary<string, int> colorMax = new() {
        {"red", 12},
        {"green", 13},
        {"blue", 14}
    };

        char[] delimiters = [':', ';', ','];
        // make an array of the parts, trimmed whitespace
        string[] parts = Array.ConvertAll(input.Split(delimiters), p => p.Trim());

        for (int i = 1; i < parts.Length; i++)
        {
            var temp = Array.ConvertAll(parts[i].Split(' '), p => p.Trim());
            (int, string) cubes = (Int32.Parse(temp[0]), temp[1]);

            // I dont like this, but its clever
            var thing = cubes.Item2 switch
            {
                "red" => mostRed = cubes.Item1 > mostRed ? cubes.Item1 : mostRed,
                "green" => mostGreen = cubes.Item1 > mostGreen ? cubes.Item1 : mostGreen,
                "blue" => mostBlue = cubes.Item1 > mostBlue ? cubes.Item1 : mostBlue,
                _ => throw new UnreachableException("Not red, green, nor blue"),
            };

        }

        gameRound = DigitRegex.Match(parts[0]).ToString();

        IsPossible = colorMax["red"] >= mostRed && 
                    colorMax["green"] >= mostGreen && 
                    colorMax["blue"] >= mostBlue;

        Console.WriteLine($"{gameRound} {IsPossible} {mostRed} {mostGreen} {mostBlue}");
    }

}

class IsGamePossible : ISolve
{




    public (string, string) Solve(string input)
    {

        string part1 = "0";

        string part2 = "0";
        CubeGame game = new(input);

        if(game.IsPossible) {
            part1 = game.gameRound.ToString();
        }

        part2 = (game.mostGreen * game.mostBlue * game.mostRed).ToString();
       
        return (part1, part2);

    }
}