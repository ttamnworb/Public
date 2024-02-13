using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidation
{

    public class Password
    {
        public Password() 
        {
        }
        public static string Validate (string password)
        {
            string result = string.Empty;

            if ((password == null) || (password.Length < 8))
            { 
                result = AppendResult(result, "Password must be at least 8 characters");
            }
            if (CountChars(password, Char.IsDigit) < 2)
            {
                result = AppendResult(result, "The password must contain at least 2 numbers");
            }
            if (CountChars(password, Char.IsUpper) < 1)
            {
                result = AppendResult(result, "password must contain at least one capital letter");
            }
            if (CountChars(password, Char.IsPunctuation) < 1)
            {
                result = AppendResult(result, "password must contain at least one special character");
            }
            return result;
        }

        /// <summary>
        /// Append new text onto the end of the current result.
        /// Each result message will be separated by a new line.
        /// </summary>
        /// <param name="currentResult">The current result (can be empty) </param>
        /// <param name="newText">The new text</param>
        /// <returns>The amalgam of the two inputs</returns>
        private static string AppendResult(string currentResult, string newText)
        {
            string result = currentResult;
            if (!string.IsNullOrEmpty(newText))
            {
                if (!string.IsNullOrEmpty(result))
                {
                    result += "\n";
                }
                result += newText;
            }
            return result;
        }
        
        /// <summary>
        /// Count the number of characters that cause the comparison function to return true in the string 
        /// </summary>
        /// <param name="input">A string</param>
        /// <returns>The number trues returned by the comparison function</returns>
        private static int CountChars(string input, Func<char, bool> compareFunc)
        {
            int result = 0;
            if (input != null)
            {
                foreach (char letter in input)
                {
                    if (compareFunc(letter))
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
