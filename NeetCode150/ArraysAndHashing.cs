namespace NeetCode150
{
    public static class ArraysAndHashing
    {
        // Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
        //https://leetcode.com/problems/top-k-frequent-elements/description/
        // Example 1:
        // Input: nums = [1,1,1,2,2,3], k = 2
        // Output: [1,2]

        public static void TopKFrequentElements()
        {
            var input = new int[] { 1, 1, 1, 2, 2, 3 };
            var k = 2;

            var map = new Dictionary<int, int>();

            foreach (var i in input)
            {
                if (!map.ContainsKey(i))
                {
                    map[i] = 1;
                }
                map[i] = map[i] + 1;
            }

            var result = map.OrderByDescending(x => x.Value).Select(x => x.Key).Take(k).ToArray();
            Console.WriteLine($"Top K Elements: {string.Join(", ", result)}");
        }


        // Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
        // The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
        // You must write an algorithm that runs in O(n) time and without using the division operation.
        // https://leetcode.com/problems/product-of-array-except-self/description/
        // Example 1:
        // Input: nums = [1,2,3,4]
        // Output: [24,12,8,6]
        public static void ProductofArrayExceptSelf()
        {
            var nums = new int[] { 1, 2, 3, 4 };

            var result = new int[] { 1, 1, 1, 1 };

            #region my code
            // int length = nums.Length;

            // int prod = 1;

            // for (int i = length - 1; i >= 0; i--)
            // {
            //     result[i] = nums[i] * prod;
            //     prod = result[i];
            //     Console.WriteLine($"{string.Join(", ", result)}");
            // }

            // prod = 1;

            // for (int i = 0; i < length - 1; i++)
            // {
            //     result[i] = prod * result[i + 1];
            //     prod *= nums[i];
            //     Console.WriteLine($"{string.Join(", ", result)}");
            // }

            // result[length - 1] = prod;
            #endregion

            #region Leet Code solution
            int[] product = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                    product[i] = 1;
                else
                    product[i] = product[i - 1] * nums[i - 1];
            }
            Console.WriteLine($"{string.Join(", ", product)}");

            int incrementproduct = 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                incrementproduct *= nums[i + 1];
                product[i] *= incrementproduct;
                Console.WriteLine($"{string.Join(", ", product)}");
            }
            // return product;
            #endregion

            Console.WriteLine($"{string.Join(", ", product)}");
        }

        //https://leetcode.com/problems/valid-sudoku/
        //9x9 board. Validate only filled numbers. Empty fields have a dot
        public static void IsValidSudoku()
        {
            char[][] board =
            {
                new char[] {'5','3','.','.','7','.','.','.','.'},
                new char[] {'6','.','.','1','9','5','.','.','.'},
                new char[] {'.','9','8','.','.','.','.','6','.'},
                new char[] {'8','.','.','.','6','.','.','.','3'},
                new char[] {'4','.','.','8','.','3','.','.','1'},
                new char[] {'7','.','.','.','2','.','.','.','6'},
                new char[] {'.','6','.','.','.','.','2','8','.'},
                new char[] {'.','.','.','4','1','9','.','.','5'},
                new char[] {'.','.','.','.','8','.','.','7','9'}
            };

            HashSet<char>[] rows = new HashSet<char>[9];
            HashSet<char>[] cols = new HashSet<char>[9];
            HashSet<char>[] boxes = new HashSet<char>[9];

            for (int i = 0; i < 9; i++)
            {
                rows[i] = new HashSet<char>();
                cols[i] = new HashSet<char>();
                boxes[i] = new HashSet<char>();
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char digit = board[i][j];
                    if (digit == '.') continue;

                    if (rows[i].Contains(digit)) Console.WriteLine("InValid Sudoku"); //return false;
                    rows[i].Add(digit);

                    if (cols[j].Contains(digit)) Console.WriteLine("InValid Sudoku"); //return false;
                    cols[j].Add(digit);

                    int boxIndex = (i / 3) * 3 + j / 3;
                    if (boxes[boxIndex].Contains(digit)) Console.WriteLine("InValid Sudoku"); //return false;
                    boxes[boxIndex].Add(digit);
                }
            }

            //calculating boxIndex is vital. You can reuse the formula for all 9x9 grids

            // return true;
            Console.WriteLine("Valid Sudoku");
        }

        //longest consecutive elements
        //https://leetcode.com/problems/longest-consecutive-sequence/description/
        public static void LongestConsecutive()
        {
            int[] nums = new int[] { 1, 2, 0, 1 };//{ 100, 4, 200, 1, 3, 2 };
            Array.Sort(nums);
            int maxCount = 1;
            int runningCount = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] == nums[i] - 1)
                {
                    runningCount++;
                }
                else if (nums[i - 1] == nums[i])
                {
                    continue;
                }
                else
                {
                    if (maxCount < runningCount) maxCount = runningCount;
                    runningCount = 1;
                }
            }
            maxCount = runningCount;

            Console.WriteLine($"Longest consecutive sequence: {maxCount}");
        }

        public static void LongestConsecutive_HashApproach()
        {
            int[] nums = new int[] { 1, 2, 0, 1 };//{ 100, 4, 200, 1, 3, 2 };
            HashSet<int> map = nums.ToHashSet();
            int maxCount = 1;
            foreach (var num in map)
            {
                int sequence = 1;
                if (!map.Contains(num - 1))
                {
                    bool found = true;
                    var current = num;
                    while (found)
                    {
                        if (map.Contains(current + 1))
                        {
                            sequence++;
                            current += 1;
                        }
                        else
                            found = false;
                    }
                }
                maxCount = Math.Max(maxCount, sequence);
            }

            Console.WriteLine($"Longest consecutive sequence: {maxCount}");
        }
    }
}