using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace lkPangilinan.RetailApp.Windows.DAL
{
    public class RetailDBContext : DbContext
    {
        public RetailDBContext() : base("myConnectionString")
        {
            Database.SetInitializer(new lkPangilinan.RetailApp.Windows.DAL.DataInitializer());
        }
        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.OrderProduct> OrderProducts { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.RetailUser> RetailUsers { get; set; }
    }
}
