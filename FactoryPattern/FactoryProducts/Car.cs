using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.FactoryProducts
{
    public class Car : IProductType
    {
        public void TotalPassengers()
        {
            Console.Write("Maximum is 4");
        }
    }
}
