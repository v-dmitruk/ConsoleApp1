using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityFrameworkTask
{
    public class ProductDBContext : DbContext
    {
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //public ProductContext() : base("DefaultConnection")
        //{
        //    OnModelCreating(new DbModelBuilder());
        //    
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}


    }
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ProductDBContext>
    {

    }

}
