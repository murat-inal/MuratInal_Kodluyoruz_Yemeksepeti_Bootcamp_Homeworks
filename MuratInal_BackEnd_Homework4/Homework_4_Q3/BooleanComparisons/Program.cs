using System;

namespace BooleanComparisons
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValid=true;

            /* ----------- Wrong Usage -------------------

            if (isValid==true)
            {
                Console.WriteLine("Valid registration");
            }
            else
            {
                Console.WriteLine("Invalid registration");
            } */

            if (isValid)
            {
                Console.WriteLine("Valid registration");
            }
            else
            {
                Console.WriteLine("Invalid registration");
            }
        }
    }
}
