namespace ChefLibrary.Products
{
    public interface IProduct
    {
        string Name { get; set; }

        double Weight { get; set; }

        Caloricity Caloricity { get; }

        double GetProductCalories();
    }
}
