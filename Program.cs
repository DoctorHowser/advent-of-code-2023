// See https://aka.ms/new-console-template for more information
// Wow, dotnet making things easy! no `main` method!

using advent_of_code_2023;

Console.WriteLine("Hello, World!");
// Day 1
NumberSearch search = new();
string[] values = File.ReadAllLines("./data/Day1.txt");
int resulta = 0;
int resultb = 0;
foreach(string value in values) {
    resulta += Int32.Parse(search.Solve(value).Item1);
    resultb += Int32.Parse(search.Solve(value).Item2);
}

Console.WriteLine($"result Day 1 Part 1 {resulta} Part 2 {resultb}");
