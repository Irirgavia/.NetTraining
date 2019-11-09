using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefLibrary.Products
{
    public class Caloricity
    {
        public double Proteins { get; private set; }
        public double Fats { get; private set; }
        public double Carbohydrates { get; private set; }
        public double Calories
        {
            get
            {
                return 9 * Fats + 4 * (Proteins + Carbohydrates);
            }
        }

        public Caloricity(
            double proteins,
            double fats,
            double carbohydrates)
        {
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }

        public override string ToString()
        {
            return $"{Proteins} proteins {Fats} fats {Carbohydrates} carbohydrates {Calories} kcal ";
        }
    }
}
