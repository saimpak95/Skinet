using Microsoft.EntityFrameworkCore;
using Skinet_DomainModels.Configurations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Skinet_DomainModels
{
   public class DataContext  : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
