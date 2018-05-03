using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GummiBearKingdom.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string imageUrl { get; set; } 
        public virtual ICollection<Review> Reviews { get; set; }

        public double AvgRating()
        {
     
            List<int> ratings = new List<int>();
            foreach (var review in Reviews)
            {
                ratings.Add(review.Rating);
            }
            return Math.Round(ratings.Average());
  
        }

        public override bool Equals(System.Object otherProduct)
        {
            if (!(otherProduct is Product))
            {
                return false;
            }
            else
            {
                Product newProduct = (Product)otherProduct;
                return this.ProductId.Equals(newProduct.ProductId);
            }
        }
    }
}
