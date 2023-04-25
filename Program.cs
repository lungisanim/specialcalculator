using System;
using System.Collections.Generic;

namespace SpecialCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> testNumbers = new List<string> { "" , "1" , "1,2" , "1\n2,3" , "//;\n1;2" , "2,1001" , "-1,2,-3,4" };
            foreach (var test in testNumbers)
            {
                Console.WriteLine(Add(test));
            }

        }

        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            char[] delimiters = GetDelimiters(ref numbers);
            string[] numArray = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            List<int> negativeNumbers = new List<int>();

            int sum = 0;
            foreach (var num in numArray)
            {
                int parsedNum;
                if (int.TryParse(num, out parsedNum))
                {
                    if (parsedNum < 0)
                        negativeNumbers.Add(parsedNum);

                    sum += parsedNum;
                }
            }

            if (negativeNumbers.Count > 0)
                throw new Exception("Negatives not allowed: " + string.Join(", ", negativeNumbers));
            
            return sum;
        }

        static char[] GetDelimiters(ref string numbers)
        {
            char[] delimiters = new char[] { ',', '\n' }; 

            if (numbers.StartsWith("//"))
            {
                int delimiterIndex = numbers.IndexOf("\n");
                string delimiterString = numbers.Substring(2, delimiterIndex - 2);
                delimiters = new char[] { Convert.ToChar(delimiterString) };
                numbers = numbers.Substring(delimiterIndex + 1);
            }

            return delimiters;
        }
    }
}
