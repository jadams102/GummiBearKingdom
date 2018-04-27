using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBearKingdom.Models
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        Product Save(Review review);
        void Remove(Review review);
    }
}
