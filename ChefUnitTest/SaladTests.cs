using ChefLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ChefLibrary.Products;
using ChefLibrary.Products.Egg;
using ChefLibrary.Products.Vegetable;
using ChefLibrary.Products.Cereal;
using static ChefLibrary.Products.Vegetable.VegetableTypes;
using static ChefLibrary.Products.Cereal.CerealTypes;

namespace ChefLibrary.Tests
{
    [TestClass()]
    public sealed class SaladTests
    {
        Salad testSalad;

        Product product1;
        Product product2;
        Product product3;
        Product product4;


        [TestInitialize()]
        public void Initialize()
        {
            product1 = new Egg("chikenEgg", 100, new Caloricity(12.7, 10.9, 0.7), "chicken", "boiled");
            product2 = new Cucumber("cucumber", 200, new Caloricity(1.8, 1.1, 2.7), "raw", CucumberType.CucumberGermanShirt);
            product3 = new Rice("baget", 100, new Caloricity(7.5, 2.9, 51.4), "milk", RiceType.RoundGrainRice);
            product4 = new Sauce("oil", 50, new Caloricity(0.0, 99.8, 0.0), "oil");

            testSalad = new Salad("testSalad", new List<Product>() { product1, product2, product3, product4});
        }

        [TestMethod()]
        public void GetWeightTest()
        {
            var expectedWeigth = 450.0;
            Assert.AreEqual(expectedWeigth, testSalad.GetWeight());
        }

        [TestMethod()]
        public void GetCaloriesTest()
        {
            /*
            1 * (9 * 10.9 + 4 * (12.7 + 0.7)) = 151.7
            2 * (9 * 1.1 + 4 * (1.8 + 2.7)) = 55.8
            1 * (9 * 2.9 + 4 * (7.5 + 51.4)) = 261.7
            0,5 * (9 * 99.8 + 4 * (0.0 + 0.0)) = 449.1

            151.7 + 55.8 + 261.7 + 449.1 = 918.3
            */

            var expectedCalories = 918.3;
            Assert.AreEqual(expectedCalories, testSalad.GetCalories());
        }

        [TestMethod()]
        public void FindProductsByNameTest()
        {
            var expectedProducts = new List<Product>() { product2 };
            Assert.AreEqual(expectedProducts.ToString(), testSalad.FindProductsByName("salad").ToString());
        }
        [TestMethod()]
        public void FindProductsByWeigthTest()
        {
            var expectedProducts = new List<Product>() { product1, product3 };
            Assert.AreEqual(expectedProducts.ToString(), testSalad.FindProductsByWeigth(100).ToString());
        }

        [TestMethod()]
        public void FindProductsByCaloriesTest()
        {
            var expectedProducts = new List<Product>() { product1, product3 };
            Assert.AreEqual(expectedProducts.ToString(), testSalad.FindProductsByCalories(150.0, 340.6).ToString());
        }

        [TestMethod()]
        public void SortByNameTest()
        {
            var expectedProducts = new List<Product>() { product3, product1, product4, product2 };
            Assert.AreEqual(expectedProducts.ToString(), testSalad.SortByName().ToString());
        }

        [TestMethod()]
        public void SortByWeigthTest()
        {
            var expectedProducts = new List<Product>() { product4, product1, product3, product2 };
            Assert.AreEqual(expectedProducts.ToString(), testSalad.SortByWeigth().ToString());
        }

        [TestMethod()]
        public void SortByCaloriesTest()
        {
            var expectedProducts = new List<Product>() { product4, product1, product3, product2 };
            Assert.AreEqual(expectedProducts.ToString(), testSalad.SortByCalories().ToString());
        }
    }
}