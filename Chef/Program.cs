using ChefLibrary;
using ChefLibrary.Products;
using ChefLibrary.Products.Cereal;
using ChefLibrary.Products.Egg;
using ChefLibrary.Products.Vegetable;
using System;
using System.Collections.Generic;
using static ChefLibrary.Products.Cereal.CerealTypes;
using static ChefLibrary.Products.Vegetable.VegetableTypes;

namespace Chef
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Product product1 = new Egg("chikenEgg", 100, new Caloricity(12.7, 10.9, 0.7), "chicken", "boiled");
                Product product2 = new Cucumber("cucumber", 200, new Caloricity(1.8, 1.1, 2.7), "raw", CucumberType.CucumberGermanShirt);
                Product product3 = new Rice("baget", 100, new Caloricity(7.5, 2.9, 51.4), "milk", RiceType.RoundGrainRice);
                Product product4 = new Sauce("oil", 50, new Caloricity(0.0, 99.8, 0.0), "oil");

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
