using FactoryPattern.Factories;
using FactoryPattern.FactoryProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.Factories
{
    public class TrainFactory : Factory
    {
        public override IProductType Create()
        {
            return new Train();
        }
    }
}
