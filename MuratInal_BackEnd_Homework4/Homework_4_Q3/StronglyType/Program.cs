using System;

namespace StronglyType
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Password");
            string userEntry = Console.ReadLine();
            bool isValid;

            /* ---------- Wrong Usage -------------
            if (userEntry == "XQaYmzT")
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }*/

            const string password = "XQaYmzT";          
            isValid = (password == userEntry) ? true : false;            
        }
    }
}
