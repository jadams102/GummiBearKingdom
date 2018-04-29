using Microsoft.VisualStudio.TestTools.UnitTesting;
using GummiBearKingdom.Models;
using System.Collections.Generic;

namespace GummiBearTests.Model_Tests
{
    [TestClass]
    public class ReviewTests
    {
        [TestMethod]
        public void Constructor_ReviewConstructorCreatesReview_Review()
        {
            Review testReview = new Review { ReviewId=1, UserName = "A User", Body = "A Body", Rating = 5 };

            Assert.AreEqual(testReview.UserName, "A User");
        }
        [TestMethod]
        public void Getters_GetReviewData_Review()
        {
            Review testReview = new Review { ReviewId = 1, UserName = "A User", Body = "A Body", Rating = 5 };

            var idResult = testReview.ReviewId;
            var userResult = testReview.UserName;
            var bodyResult = testReview.Body;
            var ratingResult = testReview.Rating;

            Assert.AreEqual(idResult, 1);
            Assert.AreEqual(userResult, "A User");
            Assert.AreEqual(bodyResult, "A Body");
            Assert.AreEqual(ratingResult, 5);
        }

        [TestMethod]
        public void Setters_SetReviewData_Review()
        {
            Review testReview = new Review { ReviewId = 1, UserName = "A User", Body = "A Body", Rating = 5 };

            testReview.ReviewId = 2;
            testReview.UserName = "A Different User";
            testReview.Body = "A Different Body";
            testReview.Rating = 3;

            Assert.AreEqual(testReview.ReviewId, 2);
            Assert.AreEqual(testReview.UserName, "A Different User");
            Assert.AreEqual(testReview.Body, "A Different Body");
            Assert.AreEqual(testReview.Rating, 3);
        }

    }
}
