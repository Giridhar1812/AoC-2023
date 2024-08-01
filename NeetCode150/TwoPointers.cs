namespace NeetCode150
{
    public static class TwoPointers
    {
        //https://leetcode.com/problems/valid-palindrome/
        //A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric 
        //characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
        //single character cannot be a palindrome   
        public static void IsPalindrome()
        {
            string inputString = "A man, a plan, a canal: Panama"; //"A man, a plan, a canal: Panama"
            if (string.IsNullOrEmpty(inputString))
            {
                Console.WriteLine($"IsPalindrome: {true}");
                return;
            }

            // var onlyLetters = "";
            // foreach(char x in inputString.ToLower())
            // {
            //     if(char.IsLetterOrDigit(x))
            //     {
            //         onlyLetters += $"{x}";
            //     }
            // }
            // Console.WriteLine(onlyLetters);

            int left = 0;
            int right = inputString.Length - 1;
            bool isPalindrome = true;
            while (left <= right)
            {
                if (!char.IsLetterOrDigit(inputString[left]))
                {
                    left++;
                    continue;
                }
                if (!char.IsLetterOrDigit(inputString[right]))
                {
                    right--;
                    continue;
                }
                if (char.ToLower(inputString[left]) != char.ToLower(inputString[right]))
                {
                    isPalindrome = false;
                    break;
                }
                left++;
                right--;
            }
            Console.WriteLine($"IsPalindrome: {isPalindrome}");
        }


        // https://neetcode.io/problems/two-integer-sum-ii
        //Return the indices (1-indexed) of two numbers, [index1, index2], such that they add up to a given target number target and index1 < index2. 
        //Note that index1 and index2 cannot be equal, therefore you may not use the same element twice.
        //Given an array of integers numbers that is sorted in non-decreasing order.
        public static void TwoSum()
        { //return int[]
            var numbers = new int[] { 2, 7, 11, 15 };
            int target = 9;
            // int[] result = new int[2];
            int left = 0;
            int right = numbers.Length - 1;

            #region dictionary approach
            // Dictionary<int, int> visited = new()
            // {
            //     { numbers[left], left }
            // };

            // while (right < numbers.Length)  
            // {
            //     if(visited.ContainsKey(target - numbers[right]))
            //     {
            //         result = new int[]{ visited[target - numbers[right]], right};
            //         break;
            //     }
            //     visited.TryAdd(numbers[right], right);
            //     right++;
            // }
            #endregion

            #region two pointer
            while (left < right)
            {
                int sum = numbers[left] + numbers[right];
                if (sum == target)
                {
                    break;
                }

                else if (sum < target)
                {
                    left++;
                }

                else //(sum > target)
                {
                    right--;
                }
            }
            #endregion

            Console.WriteLine($"Indices: {left + 1} : {right + 1}");
        }


        // https://leetcode.com/problems/3sum/description/
        // Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k
        //, and nums[i] + nums[j] + nums[k] == 0.
        // Notice that the solution set must not contain duplicate triplets.
        public static void ThreeSum() //returns IList<IList<int>>
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = new List<IList<int>>();
            Array.Sort(nums);
            // for (int i = 0; i < nums.Length - 2; i++)
            for (int i = 0; i < nums.Length - 2;)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    // if (left == i) left++;
                    // if (right == i) right--;
                    int target = 0 - nums[i];
                    int sum = nums[left] + nums[right];
                    if (sum == target)
                    {
                        var list = new List<int>() { nums[i], nums[left], nums[right] };
                        triplets.Add(list);
                        // break; This will compute only one answer for one element at a time

                        //this computes multiple answers for one element
                        while (left < right && list[1] == nums[left]) ++left;
                        while (left < right && list[2] == nums[right]) --right;
                    }
                    else if (sum < target) left++;
                    else right--;
                }
                //since multiple solutions are identified for one element, if the same element exists, skip it
                int currentNumber = nums[i];
                while (i < nums.Length - 2 && nums[i] == currentNumber)
                    ++i;
            }

            foreach (var item in triplets)
            {
                Console.WriteLine($"Triplet: {string.Join(", ", item)}");
            }
        }

        public static IList<IList<int>> ThreeSum_BetterSolution_IMO_LeetCode(int[] nums)
        {
            if (nums.Length < 3) return new List<IList<int>>();

            Array.Sort(nums);
            var triplets = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0) break; // if the first number is greater than 0, then the sum cannot be 0

                if (i > 0 && nums[i] == nums[i - 1]) continue; // skipping repeated numbers to avoid repeating triples

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        triplets.Add(new List<int>() { nums[i], nums[left], nums[right] });
                        while (left < right && nums[left] == nums[left + 1]) left++; // skipping repeated numbers to avoid repeating triples
                        while (left < right && nums[right] == nums[right - 1]) right--; // skipping repeated numbers to avoid repeating triples
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                        left++;
                    else
                        right--;
                }
            }

            return triplets;
        }


        // https://leetcode.com/problems/container-with-most-water/
        //You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
        // Find two lines that together with the x-axis form a container, such that the container contains the most water.
        // Return the maximum amount of water a container can store.
        // Notice that you may not slant the container.
        public static int MaxArea()
        {
            int[] height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int left = 0;
            int right = height.Length - 1;
            int sum = 0;
            while (left < right)
            {
                sum = Math.Max(sum, ((right - left) * Math.Min(height[left], height[right])));
                if (height[left] <= height[right])
                    left++;
                else
                    right--;
            }
            return sum;
        }


        // https://leetcode.com/problems/trapping-rain-water/description/
        // Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.
        public static void Trap() //returns int
        {
            int[] height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            //analysis so far
            //Apply the max container solution, but (r - l - 1) * min(height[l], height[r]), then subtract all numbers in between l and r
            int n = height.Length;
            if (n == 0) { Console.WriteLine($"Trapped units of water: {0}"); return; };

            int[] leftMax = new int[n];
            int[] rightMax = new int[n];

            // Calculate the maximum height from the left for each index
            leftMax[0] = height[0];
            for (int i = 1; i < n; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
            }

            // Calculate the maximum height from the right for each index
            rightMax[n - 1] = height[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], height[i]);
            }

            int waterTrapped = 0;

            // Calculate the amount of water trapped at each index
            //basically we find the before and after for each height[i], find min so that it forms a rectange, and subtract height[i] from it
            for (int i = 0; i < n; i++)
            {
                waterTrapped += Math.Min(leftMax[i], rightMax[i]) - height[i];
            }

            Console.WriteLine($"Trapped units of water: {waterTrapped}");
        }
    }
}