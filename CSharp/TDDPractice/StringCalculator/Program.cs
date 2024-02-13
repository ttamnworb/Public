using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Program
    {
        /// <summary>
        /// The method can take up to two numbers, separated by commas, and will return their sum as a result. 
        /// So the inputs can be: “”, “1”, “1,2”. 
        /// For an empty string, it will return 0.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int Add (string realInput)
        {
            // Define the default delimiters.
            List<char> seperators = new List<char>();
            seperators.Add('\n');
            seperators.Add(',');
            List<string> errorMessages = new List<string>();
            List<string> warningMessages = new List<string>();
            string input = realInput;
            int result = 0;

            // Don't allow an empty string input
            if (string.IsNullOrEmpty(input))
            {
                errorMessages.Add("No data was provided in the input string");
            }
            // Check to see if a custom delimiter is being used.
            // The input string will start //<delim>\n
            else if (input.StartsWith("//"))
            {
                if (input.Length >= 4 && input[3] == '\n')
                {
                    seperators.Clear();
                    seperators.Add(input[2]);
                    input = realInput.Substring(4);
                }
                else
                {
                    errorMessages.Add("Invalid delimiter specification.");
                }
            }
            if (errorMessages.Count < 1)
            {// Parse the string and generate the result.
                string[] numbers = input.Split(seperators.ToArray());
                foreach (string number in numbers)
                {
                    if (string.IsNullOrEmpty(number))
                    {   // There has been an issue with the split function, probably badly placed separators.
                        errorMessages.Add(string.Format("Issue parsing the input data"));
                    }
                    else
                    {
                        int value = 0;
                        if (int.TryParse(number, out value))
                        {
                            if (value < 0)
                            {
                                errorMessages.Add(string.Format("Negative values are not allowed {0}", (number)));
                            }
                            else if (value > 1000)
                            {
                                warningMessages.Add(string.Format("Number is too large {0}", (number)));
                            }
                            else
                            {
                                result += Convert.ToInt32(number);
                            }
                        }
                        else
                        {
                            errorMessages.Add(string.Format("Invalid input found {0}", number));
                        }
                    }
                }
            }
            if (DisplayMessages(errorMessages))
            {
                return 0;
            }
            _ = DisplayMessages(warningMessages);
            return result;
        }

        /// <summary>
        /// Display a list of error or warning messages and return true if a message has been shown
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        private static bool DisplayMessages (List<string> messages)
        {
            if (messages.Count > 0)
            {
                foreach (string message in messages)
                {
                    System.Console.WriteLine("{0}", message);
                }
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
        }
    }
}
