using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefLibrary.Products
{
    public abstract class Product
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public Caloricity Caloricity { get; private set; }
        public double GetProductCalories()
        {
            return Weight * Caloricity.Calories / 100;
        }

        public Product(
            string name,
            double weight,
            Caloricity caloricity
            )
        {
            Name = name;
            Weight = weight;
            Caloricity = caloricity;
        }
        public override string ToString()
        {
            return $"{Name}: {Weight}g {Caloricity.ToString()}";
        }
    }
}
