namespace ChefUnitTest
{
    using System.Collections.Generic;
    using System.Linq;

    using ChefLibrary;
    using ChefLibrary.Products;
    using ChefLibrary.Products.AnimalOriginProducts;
    using ChefLibrary.Products.MixedProducts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ChefTests
    {
        private ISalad testSalad;

        private IProduct product1;

        private IProduct product2;

        [TestInitialize]
        public void Initialize()
        {
            this.product1 = new Egg(
                "egg",
                100,
                new Caloricity(12.7, 10.9, 0.7),
                "chicken",
                Conditions.Boil);

            this.product2 = new Sauce(
                "mayonnaise",
                50,
                new Caloricity(0.0, 99.8, 0.0),
                SauceСonsistency.Thick);

            this.testSalad = new Salad("salad", new List<IProduct>() { this.product1, this.product2 });
        }

        [TestMethod]
        public void GetSaladWeightTest()
        {
            double expectedWeight = 150;
            Assert.AreEqual(
                expectedWeight,
                Chef.GetSaladWeight(this.testSalad));
        }

        [TestMethod]
        public void GetSaladCaloriesTest()
        {
            double expectedWeight = 320.8443;
            Assert.AreEqual(
                expectedWeight,
                Chef.GetSaladCalories(this.testSalad));
        }

        [TestMethod]
        public void FindProductsByNameTest()
        {
            var expectedProduct = new List<IProduct>() { this.product1 };
            Assert.AreEqual(
                expectedProduct.ToString(),
                Chef.FindProductsByName(this.testSalad, this.product1.Name).ToList().ToString());
        }

        [TestMethod]
        public void FindProductByPropertyTest()
        {
            var expectedProduct = new List<IProduct>() { this.product1 };
            Assert.AreEqual(
                expectedProduct.ToString(),
                Chef.FindProductByProperty(this.testSalad.Products, x => x.Name == this.product1.Name).ToList().ToString());
        }

        [TestMethod]
        public void FindProductsByWeightTest()
        {
            var expectedProduct = new List<IProduct>() { this.product1 };
            Assert.AreEqual(
                expectedProduct.ToString(),
                Chef.FindProductsByWeight(this.testSalad, this.product1.Weight).ToList().ToString());
        }

        [TestMethod]
        public void FindProductsByCaloriesTest()
        {
            var expectedProduct = new List<IProduct>() { this.product1 };
            Assert.AreEqual(
                expectedProduct.ToString(),
                Chef.FindProductsByCalories(this.testSalad, this.product1.GetProductCalories(), this.product1.GetProductCalories()).ToList().ToString());
        }

        [TestMethod]
        public void SortProductsByPropertyTest()
        {
            var expectedProduct = new List<IProduct>() { this.product2, this.product1 };
            Assert.AreEqual(
                expectedProduct.ToString(),
                Chef.SortProductsByProperty(this.testSalad.Products, x => x.Weight).ToList().ToString());
        }

        [TestMethod]
        public void SortSaladByNameTest()
        {
            var expectedProduct = new List<IProduct>() { this.product2, this.product2 };
            Assert.AreEqual(
                expectedProduct.ToString(),
                Chef.SortSaladByName(this.testSalad).ToList().ToString());
        }

        [TestMethod]
        public void SortSaladByWeightTest()
        {
            var expectedProduct = new List<IProduct>() { this.product2, this.product1 };
            Assert.AreEqual(
                expectedProduct.ToString(),
                Chef.SortSaladByWeight(this.testSalad).ToList().ToString());
        }

        [TestMethod]
        public void SortSaladByCaloriesTest()
        {
            var expectedProduct = new List<IProduct>() { this.product2, this.product1 };
            Assert.AreEqual(
                expectedProduct.ToString(),
                Chef.SortSaladByCalories(this.testSalad).ToList().ToString());
        }
    }
}