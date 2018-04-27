using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBearKingdom.Models;
using GummiBearKingdom.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace GummiBearTests
{
    [TestClass]
    public class ProductsControllerTests
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();

        private void DbSetUp()
        {
            mock.Setup(m => m.Products).Returns(new Product[] 
            {
                new Product {ProductId = 1, Description = "Gummi Bears!", Name = "Gummi Bears", Price = "0.17 / oz", imageUrl = "test url"},
                new Product {ProductId = 1, Description = "Gummi Worms!", Name = "Gummi Worms", Price = "0.17 / oz", imageUrl = "test url"},
                new Product {ProductId = 1, Description = "Gummi Fruit!", Name = "Gummi Fruit", Price = "0.17 / oz", imageUrl = "test url"}
            }.AsQueryable());
        }

        [TestMethod]
        public void  Mock_GetViewResultIndex_ActionResult()
        {
            DbSetUp();
            ProductsController controller = new ProductsController(mock.Object);

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }
    }
}
