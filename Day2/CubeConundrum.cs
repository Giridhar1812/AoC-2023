// https://adventofcode.com/2023/day/2
namespace AoC
{
    public static class Day2
    {
        public static string input = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        public static int FindPossibleGames()
        {
            input = input.Replace(" blue","b");
            input = input.Replace(" red","r");
            input = input.Replace(" green","g");
            Console.WriteLine(input);
            return 0;
        }
    }
}