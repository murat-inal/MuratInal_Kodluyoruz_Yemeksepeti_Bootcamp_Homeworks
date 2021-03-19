using System;

namespace Parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        /* --------- Wrong Usage --------------------------------
        public void CarDetails(string brand, string model, int modelYear, string color, decimal price, bool isAvailable)
        {
            brand = "Audi";
            model = "A5";
            modelYear = 2020;
            color = "Black";
            price = 800000;
            isAvailable = true;
        }*/

        public class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int ModelYear { get; set; }
            public string Color { get; set; }
            public decimal Price { get; set; }
            public bool IsAvailable { get; set; }
        }
    }
}
