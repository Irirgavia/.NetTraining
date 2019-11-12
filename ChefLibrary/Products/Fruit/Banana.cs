using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.Fruit.FruitTypes;

namespace ChefLibrary.Products.Fruit
{
    class Banana : Fruit
    {
        public BananaType BananaType { get; private set; }
        public Banana(
            string name,
            double weight,
            Caloricity caloricity,
            string condition,
            BananaType bananaType
            ) : base(name, weight, caloricity, condition)
        {
            BananaType = bananaType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {BananaType}";
        }
    }
}
