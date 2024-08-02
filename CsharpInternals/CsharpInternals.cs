using System.Diagnostics;

namespace CsharpInternals
{
    public class CsharpDelegates
    {
        public delegate int CalculateSum(int a, int b);
        public void Calculate(int number1, int number2, Action<int, int> printMethod) //, Func<int, int, int> operation
        {
            CalculateSum csMethod = Sum;
            var result = csMethod(number1, number2);

            printMethod(number1, number2);
            Console.WriteLine(result);
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }

        public void PrintValues(int a, int b)
        {
            Console.WriteLine($"a: {a}, b: {b}");
        }

        public void Perform()
        {
            Calculate(1, 2, (a, b) => Console.WriteLine($"a: {a}, b: {b}"));
        }
    }

    public class CsharpSemaphore
    {
        // Create a semaphore with a maximum count of 2 (two threads can enter at a time)
        static SemaphoreSlim semaphore = new SemaphoreSlim(2);

        public static async Task Main(string[] args)
        {
            // Start 5 tasks that will try to enter the semaphore
            Task[] tasks = new Task[5];
            for (int i = 0; i < 5; i++)
            {
                int taskId = i;
                tasks[i] = Task.Run(() => AccessResource(taskId));
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
        }

        static async Task AccessResource(int taskId)
        {
            Console.WriteLine($"Task {taskId} waiting to enter semaphore...");
            await semaphore.WaitAsync(); // Wait to enter the semaphore
            Console.WriteLine($"Task {taskId} entered semaphore.");

            // Simulate some work
            await Task.Delay(1000);

            Console.WriteLine($"Task {taskId} leaving semaphore.");
            semaphore.Release(); // Release the semaphore
        }
    }
}