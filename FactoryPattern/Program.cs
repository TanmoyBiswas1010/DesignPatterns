using FactoryPattern.Factories;
using FactoryPattern.FactoryProducts;
using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Press 1 for car and 2 for Train");
            string choice = Console.ReadLine();
            Factory factory = null;
            switch(choice)
            {
                case "1" :
                    factory = new CarsFactory();
                    break;
                case "2":
                    factory = new TrainFactory();
                    break;
                default:
                    break;
            }

            if (factory == null) return;

            var product = factory.Create();
            product.TotalPassengers();

            Console.ReadKey();
        }
    }
}
