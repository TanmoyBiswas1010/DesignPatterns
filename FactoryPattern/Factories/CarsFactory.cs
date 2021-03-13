using FactoryPattern.FactoryProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.Factories
{
    class CarsFactory : Factory
    {
        public override IProductType Create()
        {
            return new Car();
        }
    }
}
