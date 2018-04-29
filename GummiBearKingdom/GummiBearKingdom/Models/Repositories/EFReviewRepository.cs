using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBearKingdom.Models;
using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        GummiBearDbContext db = new GummiBearDbContext();
        public IQueryable<Review> Reviews { get { return db.Reviews; } }

        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public void Remove(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        public void RemoveAll()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Reviews;");
        }
    }
}
