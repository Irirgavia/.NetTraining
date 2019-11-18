namespace ChefLibrary
{
    public static class Constants
    {
        public const double WeightCoefficientPer100G = 0.01;

        // Digestion percents
        public const double AnimalDigestionPercent = 0.9;
        public const double MixedDigestionPercent = 0.84;
        public const double PlantDigestionPercent = 0.8;

        // Energy values
        public const double ProteinsEnergyValue = 9.29;
        public const double FatsEnergyValue = 4.1;
        public const double CarbohydratesEnergyValue = 4.1;
        public const double PectinsEnergyValue = 1.9;

        // Boiling
        public const double EggBoilingLossPercentage = 0.09;
        public const double MeatBoilingLossPercentage = 0.25;
        public const double CerealBoilingLossPercentage = 0.03;
        public const double FruitBoilingLossPercentage = 0.02;
        public const double VegetableBoilingLossPercentage = 0.04;

        // Frying
        public const double EggFryingLossPercentage = 0.13;
        public const double MeatFryingLossPercentage = 0.36;
        public const double CerealFryingLossPercentage = 0.21;
        public const double FruitFryingLossPercentage = 0.14;
        public const double VegetableFryingLossPercentage = 0.23;


        // Baking
        public const double EggBakingLossPercentage = 0.07;
        public const double MeatBakingLossPercentage = 0.28;
        public const double CerealBakingLossPercentage = 0.05;
        public const double FruitBakingLossPercentage = 0.09;
        public const double VegetableBakingLossPercentage = 0.11;


        public enum Conditions
        {
            Boil,
            Fry,
            Bake,
        }
    }
}
