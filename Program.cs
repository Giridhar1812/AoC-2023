using System.Security.Cryptography.X509Certificates;
using Algorithms;
using AoC;
using AoC_2023.Day3;
using NeetCode150;

namespace AdventOfCodePuzzles
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //var result = Day1.CalibrateDocumentDigitsAsWords(); 
            //Day2.FindProductOfLeastNumberOfCubesRequiredForEachGame();
            //Day1.CalibrateDocumentDigitsAsWords();
            //Console.WriteLine($"Result: {result}");

            // GearRatios.GetSumFromSchematic();

            // IsAnagram();
            //  GroupAnagrams(new string[] {"eat","tea","tan","ate","nat","bat"});

            // KadanesAlgorithm.GetMaxSumOfContigousSubArray(new int[] { -4, -1, -2, -7, -3, -4 });

            //NeetCode150

            // ArraysAndHashing.TopKFrequentElements();
            // ArraysAndHashing.ProductofArrayExceptSelf();
            // ArraysAndHashing.IsValidSudoku();
            // ArraysAndHashing.LongestConsecutive();
            // ArraysAndHashing.LongestConsecutive_HashApproach();

            //TwoPointers
            TwoPointers.IsPalindrome();

            // Console.ReadLine();
        }

        static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> map = new();

            for (int i = 0; i < strs.Length; i++)
            {
                // var strArr = string.Concat(strs[i].OrderBy(x => x));
                var strArr = strs[i].ToArray();
                Array.Sort(strArr);

                if (map.ContainsKey(new string(strArr)))
                {
                    map[new string(strArr)].Add(strs[i]);
                }
                else
                {
                    map[new string(strArr)] = new List<string>() { strs[i] };
                }
            }

            return map.Select(x => x.Value).Cast<IList<string>>().ToList();
        }

        static bool IsAnagram()
        {
            var s = "car";
            var t = "rat";

            if (s.Length != t.Length)
                return false;

            var map1 = new Dictionary<char, int>();
            var map2 = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (map1.ContainsKey(s[i]))
                {
                    map1[s[i]] += 1;
                }
                else
                {
                    map1.Add(s[i], 1);
                }

                if (map2.ContainsKey(t[i]))
                {
                    map2[t[i]] += 1;
                }
                else
                {
                    map2.Add(t[i], 1);
                }
                // map1.Add(s[i]);
                // map2.Add(t[i]);
            }

            foreach (var item in map1.Keys)
            {
                Console.WriteLine($"Map1: {map1[item]} Map2: {map2[item]}");
                if (!map2.ContainsKey(item) || map1[item] != map2[item])
                {
                    return false;
                }
            }
            return true;
        }
    }
}