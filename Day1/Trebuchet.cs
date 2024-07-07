// https://adventofcode.com/2023/day/1

namespace AoC
{
    public static class Day1
    {
        public static string document = $"1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet";
        public static string actualInput = $"";
        public static long CalibrateDocument()
        {
            var inputCalibrations = actualInput.Split("\n");
            long sum = 0;
            foreach (var cal in inputCalibrations)
            {
                var number = $"{cal.First(x => char.IsDigit(x))}{cal.Last(x => char.IsDigit(x))}";
                sum += int.Parse(number);
            }

            return sum;
        }

        public static long CalibrateDocumentDigitsAsWords()
        {
            var input = $"";
            var filePath = "C:/Personal_Files/Learning/GitRepo/AoC-2023/Day1/puzzle2input.txt";
            var inputLines = File.ReadAllText(filePath).Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            //$"two1nine\neightwothree\nabcone2threexyz\nxtwone3four\n4nineeightseven2\nzoneight234\n7pqrstsixteen"; //
            Dictionary<string, string> numbers = new()
            {
                { "one", "1" },
                { "two", "2" },
                { "three", "3" },
                { "four", "4" },
                { "five", "5" },
                { "six", "6" },
                { "seven", "7" },
                { "eight", "8" },
                { "nine", "9" },
            };
            var inputCalibrations = input.Split("\n");
            long sum = 0;
            var firstNumber = "";
            var secondNumber = "";
            foreach (var cal in inputLines)
            {
                Console.WriteLine($"String: {cal}");

                var currentString = cal;
                var leastIndex = cal.Length; // - 1
                var maxIndex = 0;
                var firstDigit = cal.FirstOrDefault(x => char.IsDigit(x));
                var indexOfFirstDigit = firstDigit != 0 ? cal.IndexOf(firstDigit) : 100;
                foreach (var number in numbers)
                {
                    if (currentString.Contains(number.Key))
                    {
                        if (cal.IndexOf(number.Key) < leastIndex)
                        {
                            firstNumber = number.Key;
                            leastIndex = cal.IndexOf(number.Key);
                        }
                    }
                }

                // currentString = string.IsNullOrEmpty(firstNumber) ? currentString : currentString.Replace(firstNumber, ""); //string.IsNullOrEmpty(firstNumber) ? currentString : 

                var lastDigit = cal.LastOrDefault(x => char.IsDigit(x));
                var indexOfLastDigit = lastDigit != 0 ? cal.LastIndexOf(lastDigit) : -1;
                foreach (var number in numbers)
                {
                    // Console.WriteLine($"Before: Max Index {maxIndex}, Number: {number}");
                    if (currentString.Contains(number.Key))
                    {
                        if (cal.LastIndexOf(number.Key) > maxIndex)
                        {
                            maxIndex = cal.LastIndexOf(number.Key);
                            secondNumber = number.Key;
                        }
                    }
                    // Console.WriteLine($"After: Max Index {maxIndex}, Number: {number}");
                }

                numbers.TryGetValue(firstNumber, out var firstNumberViaString);
                numbers.TryGetValue(secondNumber, out var secondNumberViaString);

                string computedFirstDigit = indexOfFirstDigit < leastIndex ? firstDigit.ToString() : firstNumberViaString ?? "";

                string? computedLastDigit = null;
                if (string.IsNullOrEmpty(secondNumberViaString) && (leastIndex > indexOfLastDigit || maxIndex > indexOfLastDigit))
                {
                    computedLastDigit = firstNumberViaString ?? null;
                }
                else if (maxIndex > indexOfLastDigit)
                {
                    computedLastDigit = secondNumberViaString ?? null;
                }
                else if (indexOfLastDigit > maxIndex)
                {
                    computedLastDigit = lastDigit.ToString();
                }
                computedLastDigit ??= lastDigit.ToString();
                // else
                // {
                //     // Console.WriteLine($"Entering last else condition : {computedLastDigit}");
                // }

                Console.WriteLine($"indexOfFirstDigit: {indexOfFirstDigit}, leastIndex: {leastIndex}, firstDigit: {firstDigit}, firstNumber: {firstNumber}");
                Console.WriteLine($"indexOfLastDigit: {indexOfLastDigit}, maxIndex: {maxIndex}, lastDigit: {lastDigit}, secondNumber: {secondNumber}");

                firstNumber = "";
                secondNumber = "";

                Console.WriteLine($"{computedFirstDigit}{computedLastDigit ?? computedFirstDigit}\n");
                sum += int.Parse($"{computedFirstDigit}{computedLastDigit ?? computedFirstDigit}");
            }
            return sum;
        }
    }
}