using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBearKingdom.Models;
using System.Collections.Generic;

namespace GummiBearTests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void Constructor_ConstructNewProduct_Product()
        {
            Product testProduct = new Product { ProductId = 1, Description = "Gummi Bears!", Name = "Gummi Bears", Price = "0.17 / oz", imageUrl = "test url" };

            Assert.AreEqual(testProduct.Name, "Gummi Bears");
        }
        [TestMethod]
        public void Setters_SetsProductInfo_Product()
        {
            Product testProduct = new Product { ProductId = 1, Description = "Gummi Bears!", Name = "Gummi Bears", Price = "0.17 / oz", imageUrl = "test url" };
            testProduct.imageUrl = "test url";
            testProduct.Description = "test description";
            testProduct.Name = "test name";
            testProduct.Price = "test price";
            testProduct.ProductId = 1;

            var imgResult = testProduct.imageUrl;
            var descResult = testProduct.Description;
            var nameResult = testProduct.Name;
            var priceResult = testProduct.Price;
            var idResult = testProduct.ProductId;

            Assert.AreEqual("test url", imgResult);
            Assert.AreEqual("test description", descResult);
            Assert.AreEqual("test name", nameResult);
            Assert.AreEqual("test price", priceResult);
            Assert.AreEqual(1, idResult);
        }
        [TestMethod]
        public void Getters_GetsProductInfo_Product()
        {
            Product testProduct = new Product { ProductId = 1, Description = "Gummi Bears!", Name = "Gummi Bears", Price = "0.17 / oz", imageUrl = "test url" };

            var idResult = testProduct.ProductId;
            var nameResult = testProduct.Name;
            var descResult = testProduct.Description;
            var priceResult = testProduct.Price;
            var urlResult = testProduct.imageUrl;

            Assert.AreEqual(idResult, 1);
            Assert.AreEqual(nameResult, "Gummi Bears");
            Assert.AreEqual(descResult, "Gummi Bears!");
            Assert.AreEqual(priceResult, "0.17 / oz");
            Assert.AreEqual(urlResult, "test url");
        }

        [TestMethod]
        public void Function_GetAvgRating_Int()
        {
            Product testProduct = new Product { ProductId = 1, Description = "Gummi Bears!", Name = "Gummi Bears", Price = "0.17 / oz", imageUrl = "test url" };
            Review testReviewOne = new Review {ReviewId = 1, UserName = "A User", Body = "A Body", ProductId = 1, Rating = 1};
            Review testReviewTwo = new Review { ReviewId = 2, UserName = "A User", Body = "A Body", ProductId = 1, Rating = 5 };
            testProduct.Reviews = new List<Review> { testReviewOne, testReviewTwo };

            double avgRating = testProduct.AvgRating();

            Assert.AreEqual(avgRating, 3);
        }
    }
}
