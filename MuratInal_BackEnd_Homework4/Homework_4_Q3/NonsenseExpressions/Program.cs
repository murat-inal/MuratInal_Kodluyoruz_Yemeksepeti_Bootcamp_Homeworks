using System;

namespace NonsenseExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your age");
            int age = Convert.ToInt32(Console.ReadLine());

            /* --------- Wrong Usage ----------------- 
            if (age > 65)
            {
                Console.WriteLine("You can retire!");
            }
            else
            {
                Console.WriteLine("Keep working");
            }*/

            int minAgeToRetire = 65;
            string message = (age > minAgeToRetire) ? "You can retire!" : "Keep working" ;
            Console.WriteLine(message);
        }
    }
}
