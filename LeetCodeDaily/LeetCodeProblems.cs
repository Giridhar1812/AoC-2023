using System.Runtime.Intrinsics.X86;
using Microsoft.VisualBasic;

namespace LeetCodeDaily
{
    public static class LeetCodeProblems
    {
        // https://leetcode.com/problems/longest-increasing-subsequence/description/
        // dynamic programming
        public static int LengthOfLIS()
        {
            int[] nums = new int[] { 4, 10, 4, 3, 8, 9 }; // { 0, 1, 0, 3, 2, 3 }; //{ 10, 9, 2, 5, 3, 7, 101, 18 }; //
            Stack<int> ints = new();
            // HashSet<int> intHash = new();
            // for (int i = 0; i < nums.Length; i++)
            // {
            //     if (intHash.Contains(nums[i]))
            //     {
            //         continue;
            //     }
            //     while (ints.Count > 0 && ints.Peek() > nums[i])
            //     {
            //         var popped = ints.Pop();
            //         intHash.Remove(popped);
            //     }
            //     intHash.Add(nums[i]);
            //     ints.Push(nums[i]);
            // }
            // Console.WriteLine("LIs: {0}", ints.Count);

            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = 1;
            }
            int lis = 1;
            int currentMin = Math.Min(int.MaxValue, nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                currentMin = Math.Min(currentMin, nums[i]);
                if (nums[i - 1] < nums[i])
                {
                    lis += 1;
                    result[i] = lis;
                }
                else
                {
                    var currIndex = i - 1;
                    while (currIndex > 0 && nums[currIndex] > nums[i])
                    {
                        currIndex--;
                    }
                    result[i] = result[currIndex];
                }
            }

            return result.Max();
        }

        public static int LengthOfLIS_Solution()
        {
            int[] nums = new int[] { 0, 1, 0, 3, 2, 3 }; // { 0, 1, 0, 3, 2, 3 }; //{ 10, 9, 2, 5, 3, 7, 101, 18 }; //
            int len = 0;
            int[] tails = new int[nums.Length];

            Console.WriteLine($"Tails: {string.Join(", ", tails)}");
            Console.WriteLine($"Len: {len}");
            foreach (int num in nums)
            {
                int left = 0, right = len;

                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (tails[mid] < num)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                tails[left] = num;
                Console.WriteLine($"Tails: {string.Join(", ", tails)}");
                if (left == len)
                {
                    len++;
                }
                Console.WriteLine($"Len: {len}");
            }

            return len;
        }


        public static int LIS_WithoutBinarySearch()
        {
            int[] nums = new int[] { 0, 1, 0, 3, 2, 3 }; // { 0, 1, 0, 3, 2, 3 }; //{ 10, 9, 2, 5, 3, 7, 101, 18 }; //
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int n = nums.Length;
            int[] dp = new int[n];
            int maxLength = 1;

            // Initialize the dp array with 1 as each element is an increasing subsequence of length 1
            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
            }

            // Build the dp array
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
                // Update the maximum length found so far
                maxLength = Math.Max(maxLength, dp[i]);
            }

            return maxLength;
        }
        // https://leetcode.com/problems/increasing-triplet-subsequence/description/
        // Given an integer array nums, return true if there exists a triple of indices (i, j, k) such that i < j < k and nums[i] < nums[j] < nums[k]. If no such indices exists, return false.
        public static bool IncreasingTriplet()
        {
            int[] nums = new int[] { 20, 100, 10, 12, 5, 13 }; // {5,4,3,2,1} //2,1,5,0,4,6
            if (nums.Length < 3) return false;
            (int index, int value) min = (0, int.MaxValue);
            (int index, int value) secondMin = (0, int.MaxValue);
            (int index, int value) max = (0, int.MinValue);

            for (int i = 0; i < nums.Length; i++)
            {
                if (min.value > nums[i] && i < nums.Length - 2)
                {
                    min = (i, nums[i]);
                }
                if (secondMin.value > nums[i] && nums[i] > min.value && i > min.index)
                {
                    secondMin = (i, nums[i]);
                    // secondMin = (i, Math.Max(min.value, secondMin.value));
                }
                if (max.value < nums[i])
                {
                    max = (i, nums[i]);
                }
                if (max.index < secondMin.index)
                {
                    max = secondMin;
                }
            }

            if (min.index < secondMin.index && secondMin.index < max.index && min.value < secondMin.value && secondMin.value < max.value)
                return true;
            else
                return false;
        }


        //Maximum Profitable Triplets With Increasing Prices I
        //https://github.com/doocs/leetcode/blob/main/solution/2900-2999/2907.Maximum%20Profitable%20Triplets%20With%20Increasing%20Prices%20I/README_EN.md
        public static int maxProfitTriplets()
        {
            int ans = -1;

            int[] prices = new int[] { 5, 4, 3, 2, 1 };
            int[] profits = new int[] { 1, 5, 3, 4, 6 };

            for (int j = 0; j < prices.Length; j++)
            {
                int left = 0;
                int right = 0;
                for (int i = 0; i < j; i++)
                {
                    if (prices[i] < prices[j] && left < profits[i])
                    {
                        left = profits[i];
                    }
                }

                for (int k = j + 1; k < prices.Length; k++)
                {
                    if (prices[k] > prices[j] && right < profits[k])
                    {
                        right = profits[k];
                    }
                }

                if (left > 0 && right > 0)
                {
                    ans = Math.Max(ans, left + right + profits[j]);
                }
            }

            Console.WriteLine(ans);
            return ans;
        }

        //https://leetcode.com/problems/rotate-array/description/
        public static void ArrayRotate()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3 % nums.Length;
            k += 1;
            // int[] result = new int[nums.Length];
            //     result[(i + k) % 7] = nums[i];

            int start = 0; int end = nums.Length - 1;

            while (start <= end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }

            start = 0; end = k - 1;
            while (start <= end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }

            start = k; end = nums.Length - 1;
            while (start <= end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }

            // for(int i = 0; i < nums.Length / 2; i++)
            // {
            //     int temp = nums[i];
            //     nums[i] = nums[(i + k + 1) % 7];
            //     nums[(i + k) % 7] = temp;
            // }

            Console.WriteLine($"{string.Join(", ", nums)}");
        }
    }
}