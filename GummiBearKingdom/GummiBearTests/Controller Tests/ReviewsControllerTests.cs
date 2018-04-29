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
    }
}
