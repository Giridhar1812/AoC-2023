using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023.Day3
{
    //https://adventofcode.com/2023/day/3
    public static class GearRatios
    {
        //...*......
        public static void GetSumFromSchematic()
        {
            var input = "..806.540......*.........*............249......904...358....*......957..867..863..........857.....264..............@....89=......97..*......";
            int sum = 0;
            string currentNumber = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    currentNumber += input[i];
                }
                else if (input[i] == '.')
                {
                    currentNumber = ".";
                }

                if (!char.IsLetterOrDigit(input[i]) && input[i] != '.')
                {
                    Console.WriteLine($"Symbol : {input[i]}");
                }
            }
        }
    }
}
