using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChefLibrary.Products.Vegetable.VegetableTypes;

namespace ChefLibrary.Products.Vegetable
{
    public class Cucumber : Vegetable
    {
        public CucumberType CucumberType { get; private set; }
        public Cucumber(
            string name,
            double weight,
            Caloricity caloricity,
            string condition,
            CucumberType cucumberType
            ) : base(name, weight, caloricity, condition)
        {
            CucumberType = cucumberType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {CucumberType}";
        }
    }
}
