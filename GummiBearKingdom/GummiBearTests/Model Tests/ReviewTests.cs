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
    }
}
