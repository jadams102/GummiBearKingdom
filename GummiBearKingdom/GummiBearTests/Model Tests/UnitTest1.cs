using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBearKingdom.Models;

namespace GummiBearTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetProductInfo_ReturnsProductInfo_Product()
        {
            var product = new Product();
            product.imageUrl = "test url";
            product.Description = "test description";
            product.Name = "test name";
            product.Price = "test price";
            product.ProductId = 1;

            var imgResult = product.imageUrl;
            var descResult = product.Description;
            var nameResult = product.Name;
            var priceResult = product.Price;
            var idResult = product.ProductId;

            Assert.AreEqual("test url", imgResult);
            Assert.AreEqual("test description", descResult);
            Assert.AreEqual("test name", nameResult);
            Assert.AreEqual("test price", priceResult);
            Assert.AreEqual(1, idResult);
        }
    }
}
