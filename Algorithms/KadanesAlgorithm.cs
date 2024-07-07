namespace Algorithms
{
    public static class KadanesAlgorithm
    {
        public static void GetMaxSumOfContigousSubArray(int[] input)
        {
            // var output = BruteForceMethod(input);
            var kOutput = KadanesAlgorithmMethod(input);
            Console.WriteLine($"Max Sum of Contigous SubArray is {kOutput}");
        }

        static int BruteForceMethod(int[] input)
        {
            int maxSum = 0;
            int arrLength = input.Length;
            for(int i = 0; i < arrLength; i++)
            {
                int currentSum = 0;
                for (int j = i; j < arrLength; j++)
                {
                    currentSum += input[j];
                    maxSum = currentSum > maxSum ? currentSum : maxSum;
                }
            }
            return maxSum;
        }

        static int KadanesAlgorithmMethod(int[] input)
        {
            int maxSum = 0;
            int currentSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                currentSum = currentSum > 0 ? currentSum : 0; //if the current sum is negative, reset to zero. 
                currentSum += input[i];
                maxSum = currentSum > maxSum ? currentSum : maxSum; 
            }

            return maxSum;
        }
    }
}