using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text.RegularExpressions;

namespace NeetCode150
{
    public static class Stacks
    {
        //https://leetcode.com/problems/valid-parentheses/
        //insert opening brackets in stack, for closing brackets pop the stack to match
        public static bool IsValidParantheses() //returns bool 
        {
            string s = "()[]{}";
            if (s.Length % 2 != 0 || s.Length == 0) { Console.WriteLine("Not valid"); return false; }

            Stack<char> stack1 = new();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    stack1.Push(s[i]);
                }
                else
                {
                    if (!stack1.Any()) return false;
                    var popped = stack1.Pop();
                    if (s[i] == ')' && popped != '(' || s[i] == ']' && popped != '[' || s[i] == '}' && popped != '{')
                    {
                        return false;
                    }
                }
            }

            return !stack1.Any();
        }

        //https://leetcode.com/problems/min-stack/
        //Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.
        public class MinStack
        {
            Stack<int> intStack = new();
            #region  mycode
            // SortedDictionary<int, int> valueOrder = new();
            // // int minimumElement = 1000000000;
            // public MinStack()
            // {

            // }

            // public void Push(int val)
            // {
            //     intStack.Push(val);
            //     // minimumElement = Math.Min(val, minimumElement);
            //     if(valueOrder.ContainsKey(val))
            //         valueOrder[val]++; 
            //     valueOrder.Add(val, 1);
            // }

            // public void Pop()
            // {
            //     var popped = intStack.Pop();
            //     // minimumElement = intStack.Any() ? intStack.OrderBy(x => x).First() : 1000000000;
            //     if(valueOrder.ContainsKey(popped) && valueOrder[popped] == 1)
            //     {
            //         valueOrder.Remove(popped);
            //     }
            //     else 
            //     {
            //         valueOrder[popped]--;
            //     }
            // }

            // public int Top()
            // {
            //     return intStack.Peek();
            // }

            // public int GetMin()
            // {
            //     return valueOrder.Any() ? valueOrder.First().Key : 0;
            // }
            #endregion

            #region Solution with Tuple
            Stack<(int val, int minVal)> stack;
            int minVal = int.MaxValue;
            public MinStack()
            {
                stack = new Stack<(int, int)>();
            }

            public void Push(int val)
            {
                if (minVal > val)
                {
                    minVal = val;
                }
                stack.Push((val, minVal));
            }

            public void Pop()
            {
                stack.Pop();
                if (stack.Count > 0)
                {
                    minVal = stack.Peek().minVal;
                }
                else
                {
                    minVal = int.MaxValue;
                }
            }

            public int Top()
            {
                return stack.Peek().val;
            }

            public int GetMin()
            {
                return stack.Peek().minVal;
            }
            #endregion
        }

        // https://leetcode.com/problems/evaluate-reverse-polish-notation/
        // You are given an array of strings tokens that represents an arithmetic expression in a Reverse Polish Notation.
        // Evaluate the expression. Return an integer that represents the value of the expression.
        public static int EvalRPN()
        {
            string[] tokens = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            Stack<int> numbers = new();

            foreach (var token in tokens)
            {
                if (int.TryParse(token, out var intToken))
                {
                    numbers.Push(intToken);
                }
                else
                {
                    if (numbers.Any())
                    {
                        var number1 = numbers.Pop();
                        var number2 = numbers.Pop();
                        switch (token)
                        {
                            case "+":
                                numbers.Push(number1 + number2);
                                break;
                            case "/":
                                numbers.Push(number2 / number1);
                                break;
                            case "*":
                                numbers.Push(number2 * number1);
                                break;
                            case "-":
                                numbers.Push(number2 - number1);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return numbers.Pop();
        }

        // https://leetcode.com/problems/generate-parentheses/description/
        // Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
        public static IList<string> GenerateParenthesis(int n)
        {
            Stack<string> pars = new();
            for (int i = 0; i < n; i++)
            {
                pars.Push("(");
            }
            for (int i = 0; i < n; i++)
            {
                pars.Push(")");
            }
            return new List<string>();
            //tbc
        }

        // https://leetcode.com/problems/daily-temperatures/description/
        //Given an array of integers temperatures represents the daily temperatures, return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature. 
        //If there is no future day for which this is possible, keep answer[i] == 0 instead.
        public static int[] DailyTemperatures()
        {
            int[] temperatures = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };
            var result = new int[temperatures.Length];
            #region o(n^2) solution
            // for (int i = 0; i < temperatures.Length; i++)
            // {
            //     int wait = 0;
            //     for (int j = i + 1; j < temperatures.Length; j++)
            //     {
            //         ++wait;
            //         if (temperatures[j] > temperatures[i])
            //         {
            //             result[i] = wait;
            //             break;
            //         }
            //     }
            // }
            #endregion

            // Stack<(int value, int index)> values = new();
            // for (int i = temperatures.Length - 1; i >= 0; i--)
            // {
            //     values.Push((temperatures[i], i));
            // }

            // var popped = values.Pop();
            // while (values.Any())
            // {
            //     if (values.Peek().value > popped.value && values.Peek().index > popped.index)
            //     {
            //         temperatures[popped.index] = values.Peek().index - popped.index;
            //         popped = values.Pop();
            //     }
            //     else
            //     {
            //         var nextElement = values.Pop();
            //         values.Push(popped);
            //         popped = nextElement;
            //     }
            // }

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < temperatures.Length; i++)
            {
                while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
                {
                    var index = stack.Pop();
                    result[index] = i - index;
                }
                stack.Push(i);
            }

            return result;
        }

        //https://leetcode.com/problems/car-fleet/
        // Input: target = 100, position = [0,2,4], speed = [4,2,1]
        // Output: 1
        // Explanation:
        // The cars starting at 0 (speed 4) and 2 (speed 2) become a fleet, meeting each other at 4. The car starting at 4 (speed 1) travels to 5.
        // Then, the fleet at 4 (speed 2) and the car at position 5 (speed 1) become one fleet, meeting each other at 6. The fleet moves at speed 1 until it reaches target.
        public static int CarFleet()
        {
            int target = 20; // 10; //12; //100;
            int finalTarget = 20; // 10; //12; //100;
            int[] position = new int[] { 6, 2, 17 }; //{ 0, 4, 2 };//{ 10, 8, 0, 5, 3 }; //{ 0, 2, 4 };
            int[] speed = new int[] { 3, 9, 2 }; //{ 2, 1, 3 }; //{ 2, 4, 1, 1, 3 }; // { 4, 2, 1 };

            #region my code
            // Stack<int> indices = new();
            // Array.Sort(position, speed);

            // int maxMovement = -1;
            // int currentMaxPosition = 0;
            // while (target > 0)
            // {
            //     for (int i = 0; i < position.Length; i++)
            //     {
            //         int movement = position[i] + speed[i];
            //         maxMovement = Math.Max(movement - currentMaxPosition, maxMovement);
            //         position[i] = movement > finalTarget ? finalTarget : movement;
            //         while (indices.Count > 0 && speed[indices.Peek()] > speed[i] && position[indices.Peek()] == position[i])
            //         {
            //             speed[indices.Pop()] = speed[i];
            //         }
            //         while (indices.Count > 0 && speed[indices.Peek()] < speed[i] && position[indices.Peek()] == position[i])
            //         {
            //             speed[i] = speed[indices.Pop()];
            //         }
            //         indices.Push(i);
            //     }
            //     currentMaxPosition += maxMovement;
            //     target -= maxMovement;
            //     maxMovement = -1;
            //     indices = new();
            // }

            // return position.GroupBy(x => x).Count();
            #endregion

            var stack = new Stack<double>();
            Array.Sort(position, speed);
            for (int i = 0; i < position.Length; i++)
            {
                var current = (double)(target - position[i]) / speed[i];
                while (stack.Any() && current >= stack.Peek())
                {
                    stack.Pop();
                }
                stack.Push(current);
            }
            return stack.Count();

            //alternative solution
            if (position.Length == 1)
                return 1;

            var stack2 = new Stack<(int Position, double Duration)>(position.Length);

            Array.Sort(position, speed);

            for (int i = position.Length - 1; i >= 0; i--)
            {
                double distance = target - position[i];
                double duration = distance / speed[i];

                if (stack.Count == 0 || duration > stack2.Peek().Duration)
                    stack2.Push((position[i], duration));
            }

            return stack.Count;
        }

        //https://leetcode.com/problems/largest-rectangle-in-histogram/description/
        //Given an array of integers heights representing the histogram's bar height where the width of each bar is 1, 
        //return the area of the largest rectangle in the histogram.
        public static int LargestRectangleArea()
        {
            int[] heights = new int[] { 2, 1, 5, 6, 2, 3 }; //{ 2, 1, 2 };// { 2, 1, 5, 6, 2, 3 }; 
            int max = heights[0];
            Stack<(int maxArea, int height)> hStack = new();
            for (int i = 0; i < heights.Length; i++)
            {

            }
            Console.WriteLine(max);
            return max;
        }

        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        public static int MaxProfit()
        {
            int[] prices = new int[] { 7, 6, 4, 3, 1 }; // { 7, 1, 5, 3, 6, 4 };
            int max = 0;
            Stack<int> indices = new();
            for (int i = 0; i < prices.Length; i++)
            {
                if (indices.Count > 0 && indices.Peek() < prices[i])
                {
                    max = Math.Max(max, prices[i] - indices.Peek());
                }
                else
                {
                    indices.Push(prices[i]);
                }
            }
            return max;

            //solution without stack
            // int left = 0;
            // int right = left + 1;
            // int globalMax = 0;

            // while (right < prices.Length) {
            //     if (prices[right] > prices[left])
            //         globalMax = Math.Max((prices[right] - prices[left]), globalMax);
            //     else 
            //         left = right;

            //     right++;
            // }

            // return globalMax;
        }

        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/description/
        public static int MaxProfit_II()
        {
            int[] prices = new int[] { 7, 1, 5, 3, 6, 4 }; //{ 1, 2, 3, 4, 5 };//{ 7, 1, 5, 3, 6, 4 };
            int profit = 0;
            Stack<int> indices = new();
            for (int i = 0; i < prices.Length; i++)
            {
                int max = 0;
                while (indices.Count > 0 && indices.Peek() < prices[i])
                {
                    max = Math.Max(max, prices[i] - indices.Peek());
                    indices.Pop();
                }
                profit += max;
                indices.Push(prices[i]);
            }
            return profit;
        }

        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/description/
        public static int MaxProfit_III()
        {
            int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            int n = prices.Length;
            int[] leftProfits = new int[n];
            int[] rightProfits = new int[n];

            // Calculate leftProfits
            int minPrice = prices[0];
            for (int i = 1; i < n; i++)
            {
                leftProfits[i] = Math.Max(leftProfits[i - 1], prices[i] - minPrice);
                minPrice = Math.Min(minPrice, prices[i]);
            }
            Console.WriteLine($"{string.Join(", ", leftProfits)}");

            // Calculate rightProfits
            int maxPrice = prices[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                rightProfits[i] = Math.Max(rightProfits[i + 1], maxPrice - prices[i]);
                maxPrice = Math.Max(maxPrice, prices[i]);
            }
            Console.WriteLine($"{string.Join(", ", leftProfits)}");

            // Combine profits
            int maxProfit = 0;
            for (int i = 0; i < n; i++)
            {
                maxProfit = Math.Max(maxProfit, leftProfits[i] + rightProfits[i]);
            }

            return maxProfit;
        }
    }
}