using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace GummiBearKingdom.Models
{
    public class GummiBearDbContext : DbContext
    {
        public GummiBearDbContext()
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=gummibear;uid=root;pwd=root;");
        }
        public GummiBearDbContext(DbContextOptions<GummiBearDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
