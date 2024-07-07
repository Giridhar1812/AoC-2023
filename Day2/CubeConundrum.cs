// https://adventofcode.com/2023/day/2
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace AoC
{
    public static class Day2
    {
        public static string input = "Game 1: 1 blue, 2 green, 3 red; 7 red, 8 green; 1 green, 2 red, 1 blue; 2 green, 3 red, 1 blue; 8 green, 1 blue\nGame 2: 12 blue, 3 green, 5 red; 1 green, 1 blue, 8 red; 2 green, 12 blue, 5 red; 7 red, 2 green, 13 blue";
        public static string[] GetInput()
        {
            string filePath = "C:/Personal_Files/Learning/GitRepo/AoC-2023/Day2/cubeConundrumInput.txt";

            string fileContent = File.ReadAllText(filePath);

            // Perform the replacement
            string modifiedContent = fileContent.Replace(" blue", "b");
            modifiedContent = modifiedContent.Replace(" red", "r");
            modifiedContent = modifiedContent.Replace(" green", "g");

            // Split the modified content into lines
            string[] lines = modifiedContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return lines;
        }
        public static int FindPossibleGames()
        {
            List<(int gameId, Dictionary<char, int> map)> resultMap = new();
            
            var gameCount = 0;
            
            var lines = GetInput();
            
            foreach (var game in lines)
            {
                var indexToStartSearch = game.IndexOf(':');
                gameCount += 1;
                var currentMap = (gameId: gameCount, map: new Dictionary<char, int>());
                for (var i = indexToStartSearch; i < game.Length; i++)
                {
                    if (char.IsDigit(game[i]))
                    {
                        var indexOfNextCharacter = char.IsDigit(game[i + 1]) ? i + 2 : i + 1;
                        var currentNumber = char.IsDigit(game[i + 1]) ? int.Parse(string.Concat(game[i], game[i + 1])) : int.Parse(game[i].ToString());
                        var nextCharacter = game[indexOfNextCharacter];
                        if (currentMap.map.TryGetValue(nextCharacter, out var number))
                        {
                            currentMap.map[nextCharacter] = currentNumber > number ? currentNumber : number;
                        }
                        else
                        {
                            currentMap.map.TryAdd(nextCharacter, currentNumber);
                        }
                    }
                }

                // foreach (var mapItem in currentMap.map)
                // {
                //     Console.WriteLine($"Colour {mapItem.Key} Number {mapItem.Value}");
                // }

                resultMap.Add(currentMap);
            }

            var sumOfGameIds = resultMap.Where(x => x.map['b'] <= 14 && x.map['g'] <= 13 && x.map['r'] <= 12).Distinct();
            foreach (var item in sumOfGameIds)
            {
                // Console.WriteLine($"GameId: {item.gameId}, Colour: {string.Join(',', item.map.Select(x => x.Key))} Values : {string.Join(',', item.map.Select(x => x.Value))}");
                Console.WriteLine($"GameId: {item.gameId}");
            }
            return sumOfGameIds.Sum(x => x.gameId);
        }

        public static int FindProductOfLeastNumberOfCubesRequiredForEachGame()
        {
            List<(int gameId, Dictionary<char, int> map)> resultMap = new();
            
            var gameCount = 0;
            
            var lines = GetInput();
            
            foreach (var game in lines)
            {
                var indexToStartSearch = game.IndexOf(':');
                gameCount += 1;
                var currentMap = (gameId: gameCount, map: new Dictionary<char, int>());
                for (var i = indexToStartSearch; i < game.Length; i++)
                {
                    if (char.IsDigit(game[i]))
                    {
                        var indexOfNextCharacter = char.IsDigit(game[i + 1]) ? i + 2 : i + 1;
                        var currentNumber = char.IsDigit(game[i + 1]) ? int.Parse(string.Concat(game[i], game[i + 1])) : int.Parse(game[i].ToString());
                        var nextCharacter = game[indexOfNextCharacter];
                        if (currentMap.map.TryGetValue(nextCharacter, out var number))
                        {
                            currentMap.map[nextCharacter] = currentNumber > number ? currentNumber : number;
                        }
                        else
                        {
                            currentMap.map.TryAdd(nextCharacter, currentNumber);
                        }
                    }
                }

                resultMap.Add(currentMap);
            }

            var sumOfGameIds = resultMap.Select(x => new {x.gameId, product = (x.map['b'] != 0 ? x.map['b'] : 1) 
                                                    * (x.map['g'] != 0 ? x.map['g'] : 1) 
                                                    * (x.map['r'] != 0 ? x.map['r'] : 1)});
            foreach (var item in sumOfGameIds)
            {
                Console.WriteLine($"GameId: {item.gameId} Product: {item.product}");
            }
            return sumOfGameIds.Sum(x => x.product);
        }
    }
}