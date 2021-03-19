using System;

namespace RuleOfSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            /*----------Wrong Usage--------------
            int minAge = 18;
            string userName = "Mr.Brown";
                        
              /*


                    

                 Other Business Codes



            *//*
             
            if (minAge >= 18 && userName.Length > 0)
            {
                Console.WriteLine("you have successfully registered");
            }*/

            int minAge = 18;
            string userName = "Mr.Brown";
            bool isValid = minAge >= 18 && userName.Length > 0;

            if (isValid)
            {
                Console.WriteLine("You have successfully registered");
            }

            /*
             * 
             * 
             * 
             * Other Business Codes
             * 
             * 
             * 
             * 
             */
        }
    }
}
