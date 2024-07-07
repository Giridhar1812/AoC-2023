namespace NeetCode150
{
    public static class TwoPointers
    {
        //https://leetcode.com/problems/valid-palindrome/
        //A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric 
        //characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

        public static void IsPalindrome() {
            string inputString = "A man, a plan, a canal: Panama";
            inputString = inputString.Where(x => char.IsAsciiLetter(x)).ToString();
            Console.WriteLine(inputString);
        }
    }
}