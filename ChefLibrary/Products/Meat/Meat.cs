using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefLibrary.Products.Meat
{
    public class Meat : Product
    {
        public string Animal { get; private set; }
        public string Сondition { get; private set; }
        public Meat(
            string name,
            double weight,
            Caloricity caloricity,
            string animal,
            string condition
            ) : base(name, weight, caloricity)
        {
            Animal = animal;
            Сondition = condition;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {Сondition}";
        }
    }
}
