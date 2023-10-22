/* 

YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Initilizing list to store missing values
                List<IList<int>> result = new List<IList<int>>();
                // Initializing variable to keep track of next number
                long next = lower;

                foreach (int num in nums)
                {
                    if (num > next)  // Condition to check if num is greater than next number
                    {
                        if (num - next == 1)  // if difference is 1, then only one missing number
                        {
                            // missing value
                            result.Add(new List<int> { (int)next, (int)next });
                        }
                        // difference is more than 1, then it has range of values
                        else if (num - next > 1)
                        {
                            // Adding missing values range
                            result.Add(new List<int> { (int)next, (int)(num - 1) });
                        }
                    }

                    // pass to next iteration for expected number
                    next = (long)num + 1;
                }

                if (next <= upper)
                {
                    if (upper - next == 0)
                    {
                        // single missing value
                        result.Add(new List<int> { (int)next, (int)next });
                    }
                    // range of missing values
                    else if (upper - next > 0)
                    {
                        // Add missing values range
                        result.Add(new List<int> { (int)next, (int)upper });
                    }
                }

                // Return the missing values range
                return result;
            }
            catch (Exception)
            {
                // handling any exception that may occur
                throw;
            }
        }


        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Creating stack to store brackets
                Stack<Char> st = new Stack<Char>();

                // Converting string to a character array for easy traversal
                var CharArray = s.ToCharArray();

                for (int i = 0; i < CharArray.Length; i++)
                {
                    if (CharArray[i] == '(' || CharArray[i] == '[' || CharArray[i] == '{')
                    {
                        // If array is equal to opening bracket, push it to the stack
                        st.Push(CharArray[i]);
                        continue;
                    }
                    else if (st.Count == 0)
                    {
                        // If there's no matching opening bracket for a closing bracket, the string is invalid.
                        return false;
                    }
                    Char top = st.Pop();

                    if (top == '(' && CharArray[i] != ')')
                    {
                        return false;
                    }

                    else if (top == '[' && CharArray[i] != ']')
                    {
                        return false;
                    }
                    else if (top == '{' && CharArray[i] != '}')
                    {
                        return false;
                    }
                }

                // If the stack is empty,we found match for all brackets and string is valid
                return st.Count == 0;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur.
                throw;
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Initialize the maximum profit and minimum price for first element of array
                int max = 0;
                int min = prices[0];

                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] < min)
                    {
                        // Update the minimum price if you come across smaller value
                        min = prices[i];
                    }
                    else if ((prices[i] - min) > max)
                    {
                        // Calculate the maximum profit and update if a better opportunity is found
                        max = prices[i] - min;
                    }
                }
                // return max profit value
                return max;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur.
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)

        {
            try
            {
                Dictionary<char, char> pairs = new Dictionary<char, char>() {

    {'0', '0'},

    {'1', '1'},

    {'6', '9'},

    {'8', '8'},

    {'9', '6'}
  };

                int left = 0;
                int right = s.Length - 1;
                while (left <= right)
                {
                    if (!pairs.ContainsKey(s[left]) || pairs[s[left]] != s[right])
                    {
                        return false;

                    }
                    left++;
                    right--;
                }
                return true;

            }
            catch (Exception)
            {
                // handling any exception that may occur
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Creating dictionary to store result
                Dictionary<int, int> countDict = new Dictionary<int, int>();
                // intialize count of good pairs
                int goodPairs = 0;

                foreach (int num in nums)
                {
                    if (countDict.ContainsKey(num))
                    {
                        // If number exists in dictionary, then increment the good pair
                        goodPairs += countDict[num];

                        // Incrementing count for current number
                        countDict[num]++;
                    }
                    else
                    {
                        // Initializing count for new number
                        countDict[num] = 1;
                    }
                }

                // Return number of good pairs
                return goodPairs;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur.
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Creating hashset to store unique numbers
                HashSet<int> set = new HashSet<int>();

                foreach (int num in nums)
                {
                    // Adding each number to hashset to have uniqueness
                    set.Add(num);

                    if (set.Count > 3)
                    {
                        // If the HashSet contains more than 3 numbers, remove smallest number
                        set.Remove(set.Min());
                    }
                }

                if (set.Count < 3)
                {
                    // If hashset has more than 3 numbers, return the maximum number
                    return set.Max();
                }

                // return minimum value
                return set.Min();
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur.
                throw;
            }
        }


        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // creating a list to store resultant list
                List<string> possibleMoves = new List<string>();

                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // condition to check if current position and the next position have "++"
                        // If condition is true, create a string with "++" flipped to "--" at this position
                        string nextState = currentState.Substring(0, i) + "--" + currentState.Substring(i + 2);
                        // Add state to possible moves
                        possibleMoves.Add(nextState);
                    }
                }

                // Return all possible moves
                return possibleMoves;
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur.
                throw;
            }
        }


        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            try
            {
                // Creating string builder to store the result
                StringBuilder result = new StringBuilder();

                // Iteration for each charecter in the string
                foreach (char c in s)
                {
                    // Checking if charecter is not a vowel
                    if (c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u')
                    {
                        result.Append(c);
                    }
                }

                return result.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}