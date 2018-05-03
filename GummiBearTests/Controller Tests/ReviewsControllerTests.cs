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
    public class ReviewsControllerTests
    {
        Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
        EFProductRepository dbProd = new EFProductRepository(new TestDbContext());
        EFReviewRepository db = new EFReviewRepository(new TestDbContext());

        private void DbSetUp()
        {
            mock.Setup(m => m.Reviews).Returns(new Review[]
            {
                new Review {ReviewId = 1, Body = "A Review", Rating=4, UserName="A User"},
                new Review {ReviewId = 2, Body = "Another Review", Rating=4, UserName="Another User"},
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult()
        {
            DbSetUp();
            ReviewsController controller = new ReviewsController(mock.Object);

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }
        [TestMethod]
        public void Mock_IndexContainsModelData_List()
        {
            DbSetUp();
            ViewResult indexView = new ReviewsController(mock.Object).Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(List<Review>));
        }
        [TestMethod]
        public void Mock_IndexContainsReviews_Collection()
        {
            DbSetUp();
            ReviewsController controller = new ReviewsController(mock.Object);
            Review review = new Review { ReviewId = 1, Body = "A Review", Rating = 4, UserName = "A User" };

            ViewResult indexView = controller.Index() as ViewResult;
            List<Review> collection = indexView.ViewData.Model as List<Review>;

            CollectionAssert.Contains(collection, review);
        }
        [TestMethod]
        public void testDb_Create_AddsToDb()
        {
            ReviewsController controller = new ReviewsController(db);
            ProductsController prodController = new ProductsController(dbProd);
            Product testProduct = new Product { ProductId = 1, Description = "Gummi Bears!", Name = "Gummi Bears", Price = "0.17 / oz", imageUrl = "test url" };
            Review testReview = new Review { ReviewId = 1, Body = "A Review", Rating = 4, UserName = "A User", ProductId = 1 };

            prodController.Create(testProduct);
            controller.Create(testReview);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Review>;

            CollectionAssert.Contains(collection, testReview);
            db.RemoveAll();
        }
        [TestMethod]
        public void testDb_Delete_RemovesFromDb()
        {
            ReviewsController controller = new ReviewsController(db);
            ProductsController prodController = new ProductsController(dbProd);
            Product testProduct = new Product { ProductId = 1, Description = "Gummi Bears!", Name = "Gummi Bears", Price = "0.17 / oz", imageUrl = "test url" };
            Review testReview = new Review { ReviewId = 1, Body = "A Review", Rating = 4, UserName = "A User", ProductId = 1 };

            prodController.Create(testProduct);
            controller.Create(testReview);
            controller.DeleteConfirmed(testReview.ReviewId);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Review>;

            CollectionAssert.DoesNotContain(collection, testReview);
            db.RemoveAll();

        }
    }
}
