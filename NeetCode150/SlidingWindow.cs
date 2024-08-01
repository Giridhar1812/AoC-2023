using System.Globalization;

namespace NeetCode150
{
    public static class SlidingWindow
    {
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        public static int MaxProfit()
        {
            int[] prices = new int[] { 7, 6, 4, 3, 1 };

            if (prices.Length < 2) return 0;

            int profit = 0;
            int left = 0, right = 1;
            while (left < right && right < prices.Length)
            {
                profit = Math.Max(profit, prices[right] - prices[left]);
                if (prices[right] <= prices[left])
                {
                    left = right;
                    right++;
                }
                else
                {
                    right++;
                }
            }
            return profit;
        }

        //https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
        public static int LengthOfLongestSubstring()
        {
            string s = "abba";
            if (s.Length == 0) return 0;
            if (s.Length == 1) return 1;
            int lol = 0;
            Dictionary<char, int> charIndex = new();

            int left = 0, right = 0;
            while (right < s.Length)
            {
                if (charIndex.ContainsKey(s[right]))
                {
                    left = Math.Max(left, charIndex[s[right]] + 1);
                }
                charIndex[s[right]] = right;
                lol = Math.Max(lol, right - left + 1);
                right++;
            }

            return lol;
        }

        //https://leetcode.com/problems/longest-repeating-character-replacement/
        public static int CharacterReplacement()
        {
            string s = "ABBB";
            int k = 2;
            if (s.Length == 0) return 0;
            // char currentChar = s[0];
            // int remaningReplacement = k;
            int maxFrequency = 0;
            int result = 0;
            Dictionary<char, int> charFrequency = new();
            int left = 0;
            for (int right = 0; right < s.Length; right++)
            {
                // if (s[right] != currentChar)
                //     remaningReplacement -= 1;

                // if(remaningReplacement < 0)
                // {
                //     left = Math.Max(left, charIndex.ContainsKey(s[right]) ? charIndex[s[right]] + 1 : right);
                //     currentChar = s[left];
                //     remaningReplacement = k;
                // }

                // charIndex[s[right]] = right;
                // result = Math.Max(result, right - left + 1);
                if(charFrequency.ContainsKey(s[right]))
                {
                    charFrequency[s[right]]++;
                }
                else
                {
                    charFrequency[s[right]] = 1;
                }

                maxFrequency = Math.Max(maxFrequency, charFrequency[s[right]]);

                if((right - left + 1) - maxFrequency > k)
                {
                    charFrequency[s[left]]--;
                    left++;
                }

                result = Math.Max(result, right - left + 1);
            }
            Console.WriteLine(result);
            return result;
        }
    }
}