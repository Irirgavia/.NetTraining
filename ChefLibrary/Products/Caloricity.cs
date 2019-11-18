namespace ChefLibrary.Products
{
    public class Caloricity
    {
        public Caloricity(
            double proteins,
            double fats,
            double carbohydrates)
        {
            this.Proteins = proteins;
            this.Fats = fats;
            this.Carbohydrates = carbohydrates;
        }

        public double Proteins { get; set; }

        public double Fats { get; set; }

        public double Carbohydrates { get; set; }

        public double GetCaloriesPer1G()
        {
            return (Constants.ProteinsEnergyValue * this.Proteins) 
                   + (Constants.FatsEnergyValue * this.Fats)
                   + (Constants.CarbohydratesEnergyValue * this.Carbohydrates);
        }

        public override string ToString()
        {
            return $"{this.Proteins} proteins {this.Fats} fats {this.Carbohydrates} carbohydrates";
        }
    }
}
