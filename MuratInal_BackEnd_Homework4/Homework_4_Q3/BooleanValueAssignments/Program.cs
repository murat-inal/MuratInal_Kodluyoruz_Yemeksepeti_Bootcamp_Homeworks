using System;

namespace BooleanValueAssignments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your grade");
            int grade = Convert.ToInt32(Console.ReadLine());

            /* ----------- Wrong Usage---------
            bool isPassed;
            if (grade > 50)
            {
                isPassed = true;
            }
            else
            {
                isPassed = false;
            }*/

            bool isPassed = grade >= 35;

            Console.WriteLine(isPassed);

        }
    }
}
