namespace ChefUnitTest
{
    using System.Collections.Generic;

    using ChefLibrary;
    using ChefLibrary.Products;
    using ChefLibrary.Products.AnimalOriginProducts;
    using ChefLibrary.Products.MixedProducts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class SaladTests
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

            this.testSalad = new Salad("salad", new List<IProduct>() { this.product1 });
        }

        [TestMethod]
        public void AddProductTest()
        {
            this.testSalad.AddProduct(this.product2);
            var expectedSalad = new Salad("salad", new List<IProduct>() { this.product1, this.product2 });
            Assert.AreEqual(expectedSalad.ToString(), this.testSalad.ToString());
        }

        [TestMethod]
        public void RemoveProductTest()
        {
            this.testSalad.RemoveProduct(this.product1);
            var expectedSalad = new Salad("salad", new List<IProduct>());
            Assert.AreEqual(expectedSalad.ToString(), this.testSalad.ToString());
        }
    }
}