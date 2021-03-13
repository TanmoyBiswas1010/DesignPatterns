using FactoryPattern.FactoryProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.Factories
{
    public abstract class Factory
    {
        public abstract IProductType Create();
    }
}
