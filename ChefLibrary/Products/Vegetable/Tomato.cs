using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.Vegetable.VegetableTypes;

namespace ChefLibrary.Products.Vegetable
{
    public class Tomato : Vegetable
    {
        public TomatoType TomatoType { get; private set; }
        public Tomato(
            string name,
            double weight,
            Caloricity caloricity,
            string condition,
            TomatoType tomatoType
            ) : base(name, weight, caloricity, condition)
        {
            TomatoType = tomatoType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {TomatoType}";
        }
    }
}
