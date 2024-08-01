namespace NeetCode150
{
    public static class BinarySearch
    {
        //https://leetcode.com/problems/binary-search/description/
        public static int Search()
        {
            int[] nums = new int[] { -1, 0, 3, 5, 9, 12 };
            int target = 10;
            int result = -1;
            int left = 0;
            int right = nums.Length - 1;
            int midpoint;

            while (left <= right)
            {
                midpoint = left + (right - left) / 2;
                if (nums[midpoint] == target)
                {
                    result = midpoint;
                    break;
                }

                if (nums[midpoint] < target)
                    left = midpoint + 1;

                if (nums[midpoint] > target)
                    right = midpoint - 1;
            }

            return result;
        }

        // https://leetcode.com/problems/search-a-2d-matrix/description/
        public static bool SearchMatrix()
        {
            // int[][] matrix = new int[][] { new int[] { 1, 3, 5, 7 }, new int[] { 10, 11, 16, 20 }, new int[] { 23, 30, 34, 60 } };

            int[][] matrix = new int[][] { new int[] { 1, 3 } };
            int target = 3;

            if (matrix.Length == 1 && matrix[0].Length == 1)
            {
                if (matrix[0][0] == target) return true;
                else return false;
            }

            int size = matrix.Length * matrix[0].Length;
            int colSize = matrix[0].Length;
            int left = 0; int right = size - 1;
            int mid;
            // for (int i = 0; i < size - 1; i++)
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (matrix[mid / colSize][mid % colSize] == target)
                {
                    return true;
                }
                if (matrix[mid / colSize][mid % colSize] < target)
                {
                    left = mid + 1;
                }
                if (matrix[mid / colSize][mid % colSize] > target)
                {
                    right = mid - 1;
                }
            }
            return false;
        }

        //https://leetcode.com/problems/koko-eating-bananas/description/
        public static int MinEatingSpeed()
        {
            int[] piles = new int[] { 3, 6, 7, 11 }; // { 30, 23, 11, 4, 20 };
            int h = 8;
            // Array.Sort(piles);
            // int mid = piles[(piles.Length - 1) / 2];
            // int speed = 0;
            // int minElement = int.MaxValue;

            // while (mid <= piles[piles.Length - 1] && mid >= piles[0])
            // {
            //     speed = 0;
            //     for (int i = 0; i < piles.Length; i++)
            //     {
            //         speed += (piles[i] / mid) + (piles[i] % mid > 0 ? 1 : 0);
            //     }

            //     if (speed == h)
            //     {
            //         minElement = Math.Min(minElement, mid);
            //         if (minElement == piles[0] || minElement == piles[piles.Length - 1]) break;
            //         mid -= 1;
            //     }
            //     if (speed > h)
            //     {
            //         mid += 1;
            //     }
            //     else if (speed < h)
            //     {
            //         mid -= 1;
            //     }
            // }

            // return minElement;

            int left = 1;
            int right = piles.Max();
            int result = right;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                int hours = 0;
                foreach (int pile in piles)
                {
                    hours += (int)Math.Ceiling((double)pile / (double)middle);
                }

                if (hours < 0) break;

                if (hours <= h)
                {
                    result = Math.Min(result, middle);
                    Console.WriteLine($"{hours} and {middle}: {result}");
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return result;
        }

        // https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/
        public static int FindMinInRotatedArray()
        {
            int[] nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            int min = 0;
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[right] > nums[mid])
                {
                    right = mid;
                }
                else //if (nums[left] < nums[mid])
                {
                    left = mid + 1;
                }
            }
            Console.WriteLine(nums[right]);
            return min;
        }

        //https://leetcode.com/problems/search-in-rotated-sorted-array/
        public static int SearchInRotatedSortedArray()
        {
            int[] nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            int target = 3;

            if (nums.Length == 1)
            {
                return nums[0] == target ? 0 : -1;
            }

            int result = -1;
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return result;
        }
    }
}