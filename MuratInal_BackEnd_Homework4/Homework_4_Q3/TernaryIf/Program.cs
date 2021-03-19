using System;

namespace TernaryIf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            int number = Convert.ToInt32(Console.ReadLine());
            bool isEven;
            /* --------------- Wrong Usage --------------
            if (number %2 == 0)
            {
                isEven = true;
            }
            else
            {
                isEven = false;
            }*/

            isEven = (number % 2 == 0) ? true : false;
        }
    }
}
