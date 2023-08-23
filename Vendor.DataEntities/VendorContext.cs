using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendor.DataEntities.Models;

namespace Vendor.DataEntities
{
    public class VendorContext: DbContext
    {
        public VendorContext(DbContextOptions<VendorContext> options) :base(options)
        { 
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Vendors> Vendors { get; set; }
        public DbSet<VendorProductsTable> Products { get; set; }
        public DbSet<VendorCategoriesTable> Categories { get; set; }
        public DbSet<VendorProductCategoryTable> ProductCategories { get; set; }
        public DbSet<VendorOrderTable> Orders { get; set; }
        public DbSet<VendorOrderItemTable> OrderItems { get; set; }
        public DbSet<VendorNotificationTable> Notifications { get; set; }
    }
}
