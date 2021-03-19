using System;

namespace BePositive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your age");
            int age = Convert.ToInt32( Console.ReadLine());
            bool isUnder18 = age < 18;
            /* ----------- Wrong Usage ----------------------------
            if (!isUnder18)
            {
                Console.WriteLine("You can take a driving licence!");
            }
            else
            {
                Console.WriteLine("You cannot take a driving licence!");
            } */

            if (isUnder18)
            {
                Console.WriteLine("You cannot take a driving licence!");
            }
            else
            {
                Console.WriteLine("You can take a driving licence!");
            }
        }
    }
}
