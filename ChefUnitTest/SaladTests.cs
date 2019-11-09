using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ChefLibrary.Products;
using static ChefLibrary.Products.ProductTypes.ProductTypes;

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
            testSalad = new Salad("testSalad", new List<Product>());

            product1 = new Egg("chikenEgg", 100, new Caloricity(12.7, 10.9, 0.7), EggType.Chicken);
            product2 = new Vegetable("salad", 200, new Caloricity(1.8, 1.1, 2.7), VegetableType.Salad);
            product3 = new Cereal("baget", 100, new Caloricity(7.5, 2.9, 51.4), CerealType.Millet);
            product4 = new Sauce("oil", 50, new Caloricity(0.0, 99.8, 0.0), SauseType.Oil);

            testSalad.AddProduct(product1);
            testSalad.AddProduct(product2);
            testSalad.AddProduct(product3);
            testSalad.AddProduct(product4);
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