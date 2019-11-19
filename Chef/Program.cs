﻿namespace Chef
{
    using System;

    using ChefLibrary;
    using ChefLibrary.Builders;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var chef = new Chef(new OlivierSaladBuilder());
                var salad = chef.BuildSalad();

                Console.WriteLine(salad.ToString());

                Console.WriteLine($"Salad weight: {Chef.GetSaladWeight(salad)}g");
                Console.WriteLine($"Salad caloricity: {Chef.GetSaladCalories(salad)} kcal \n");

                Console.WriteLine("Sort product by calories:");
                foreach (var product in Chef.SortSaladByCalories(salad))
                {
                    Console.WriteLine(product);
                }

                double beginValue = 400;
                double endValue = 1500;

                Console.WriteLine($"\nFind product with {beginValue}-{endValue} caloricity:");
                foreach (var product in Chef.FindProductsByCalories(salad, beginValue, endValue))
                {
                    Console.WriteLine(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
