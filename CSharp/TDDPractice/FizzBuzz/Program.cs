using System;

namespace FizzBuzz
{
    public class Program
    {
        public static string FizzBuzz (int n)
        {
            if (((n % 3) == 0) && ((n % 5) == 0))
            {
                return "FizzBuzz";
            }
            if ((n % 3) == 0)
            {
                return "Fizz";
            }
            if ((n % 5) == 0)
            {
                return "Buzz";
            }
            return Convert.ToString (n);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
        }
    }
}
