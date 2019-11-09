using ChefLibrary;
using ChefLibrary.Products;
using System;
using System.Collections.Generic;
using static ChefLibrary.Products.ProductTypes.ProductTypes;

namespace Chef
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Product product1 = new Egg("chikenEgg", 100, new Caloricity(12.7, 10.9, 0.7), EggType.Chicken);
                Product product2 = new Vegetable("salad", 200, new Caloricity(1.8, 1.1, 2.7), VegetableType.Salad);
                Product product3 = new Cereal("baget", 100, new Caloricity(7.5, 2.9, 51.4), CerealType.Millet);
                Product product4 = new Sauce("oil", 50, new Caloricity(0.0, 99.8, 0.0), SauseType.Oil);

                Salad salad = new Salad("testSalad", new List<Product>() { product1, product2, product3, product4});

                Console.WriteLine("Salad components:");
                foreach(var product in salad.Products)
                {
                    Console.WriteLine(product.ToString());
                }

                Console.WriteLine("---");

                Console.WriteLine($"Salad weigth: {salad.GetWeight()}");
                Console.WriteLine($"Salad caloricity: {salad.GetCalories()}");

                Console.WriteLine("---");

                Console.WriteLine("Sort salad products by name:");
                foreach (var product in salad.SortByName())
                {
                    Console.WriteLine(product.ToString());
                }

                Console.WriteLine("---");

                Console.WriteLine("Salad products with 150.0 - 320.0 caloricity:");
                foreach (var product in salad.FindProductsByCalories(150.0, 320.0))
                {
                    Console.WriteLine(product.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
