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
        [TestMethod]
        public void Mock_IndexContainsModelData_List()
        {
            DbSetUp();
            ViewResult indexView = new ProductsController(mock.Object).Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(List<Product>));
        }
        [TestMethod]
        public void Mock_IndexContainsItems_Collection()
        {
            DbSetUp();
            ProductsController controller = new ProductsController(mock.Object);
            Product product = new Product { ProductId = 1, Description = "Gummi Bears!", Name = "Gummi Bears", Price = "0.17 / oz", imageUrl = "test url" };

            ViewResult indexView = controller.Index() as ViewResult;
            List<Product> collection = indexView.ViewData.Model as List<Product>;

            CollectionAssert.Contains(collection, product);
        }
        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            Product product = new Product { ProductId = 1, Description = "Gummi Bears!", Name = "Gummi Bears", Price = "0.17 / oz", imageUrl = "test url" };
            DbSetUp();
            ProductsController controller = new ProductsController(mock.Object);

            var resultView = controller.Details(product.ProductId) as ViewResult;
            var model = resultView.ViewData.Model as Product;

            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Product));
        }

    }
}
