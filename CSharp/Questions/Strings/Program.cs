namespace Strings
{
    internal class Program
    {
        /// <summary>
        /// Is the given strung a palindrome
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True f it is</returns>
        static bool IsPalindrome(string input)
        {
            bool result = true;         // Assume it is until proven otherwise.
            if (string.IsNullOrEmpty(input))
            {   // If the string is null or empty then it is NOT a palindrome (is this correct).
                result = false;
            }
            else
            {
                int front = 0;                  // The index into the string starting at the front.
                int back = input.Length - 1;    // The index into the string starting at the back.
                while (front < back)            // ensure that the pointers don't overlap.
                {
                    if (input[front++] != input[back--])
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Print the numbers 1 to n (inclusive).
        /// If a number is a multiple of 3 print Fizz instead of the number
        /// If a number is a multiple of 5 print Buzz instead of the number
        /// If a number is a multiple of 3 and 5 print FizzBuzz instead of the number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static string FizzBuzz (int number)
        {
            string output = "";
            for (int current = 1; current <= number; current++)
            {
                if (current == 0)
                {
                    output += "0";
                }
                if (current % 15 == 0)
                {
                    output += "FizzBuzz";
                }
                else if (current % 5 == 0)
                {
                    output += "Buzz";
                }
                else if (current % 3 == 0)
                {
                    output += "Fizz";
                }
                else
                {
                    output += Convert.ToString(current);
                }
                if (current < number)
                {
                    output += ", ";
                }
            }
            return output;
        }

        /// <summary>
        /// If all characters in a string are unique then return true
        /// otherwise return false
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static bool uniqueCharacters (string input)
        {
            if (input.Length < 1)
            {   // This is an empty string
                return false;   
            }
            if (input.Length == 1)
            {   // One character on the string it must be unique.
                return true;
            }
            for (int index = 0; index < input.Length; index++)
            {
                char currentCharacter = input[index];
                int next = input.IndexOf(currentCharacter, index + 1);
                if (next != -1)
                {   // there is a match
                    Console.WriteLine("Match of '{0}' found at {1}", currentCharacter, next);
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            {   // Test palindrome
                string[] palindromes =
                {
                    "ABBA",     // True
                    "WOOF",     // False
                    "ZIGGY",    // False
                    "BAGAB",    // True
                    "Abba",     // False
                };

                Console.WriteLine("Test Palindrome");
                foreach (string palindrome in palindromes)
                {
                    Console.WriteLine("IsPalindrome({0}) = {1}", palindrome, (IsPalindrome(palindrome) ? "True" : "False"));
                }
            }
            {
                // Test fizz buzz
                int[] fizzbuzzes =
                {
                    4,      // 1, 2, Fizz, 4
                    6,      // 1, 2, Fizz, 4, Buzz, Fizz
                    5,      // 1, 2, Fizz, 4, Buzz
                    16,     // 1, 2, Fizz, 4 Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, FizzBuzz, 16
                    0,      //
                    -4,     //
                 };
                Console.WriteLine("");
                Console.WriteLine("Test FizzBuzz");
                foreach (int fizzbuzz in fizzbuzzes)
                {
                    Console.WriteLine("FizzBuzz({0}) = {1}", fizzbuzz, FizzBuzz(fizzbuzz));
                }
            }
            {
                // Test fizz buzz
                string[] uniqueStrings =
                {
                    "",
                    " ",
                    "abcdef",
                    "abcabc",
                    "ABCabc",
                    "1234567890qwertyuiopasdfghjklzxcvbnm",
                    "1234567890qwertyuiopasdfghjklzxcvbnmz",
                 };
                Console.WriteLine("");
                Console.WriteLine("Test Unique Strings");
                foreach (string unique in uniqueStrings)
                {
                    Console.WriteLine("uniqueCharacters({0}) = {1}", unique, uniqueCharacters(unique));
                }
            }
            // End
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}