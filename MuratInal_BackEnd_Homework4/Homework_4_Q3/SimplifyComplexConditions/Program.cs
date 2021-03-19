using System;

namespace SimplifyComplexConditions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your travel points");
            int travelPoints = Convert.ToInt32(Console.ReadLine());

            /* -------------- Wrong Usage -------------------------------------------
            if (age < 20 && travelPoints >= 40)
            {
                Console.WriteLine("Congratulations! You have won free travel ticket.");
            }*/

            const int maxAge = 20;
            const int minPoint = 40;

            bool freeTravelTicket = (age < maxAge) && (travelPoints >= 40);

            if (freeTravelTicket)
            {
                Console.WriteLine("Congratulations! You have won free travel ticket.");
            }
        }
    }
}
