namespace LeetCodeDaily
{
    public static class LeetCodeDailyChallenge
    {
        //https://leetcode.com/problems/water-bottles/
        public static void Bottles()
        {
            int numBottles = 15; int numExchange = 4;
            int result = numBottles;
            int quotient = numBottles / numExchange;

            while(quotient > 0)
            {
                if (quotient > 0)
                {
                    result += numBottles / numExchange;
                    numBottles = quotient + (numBottles % numExchange);
                }
                quotient = numBottles / numExchange;
            }


            Console.WriteLine($"Number of bottles drunk: {result}");
        }
    }
}