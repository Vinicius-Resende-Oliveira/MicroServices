using Microsoft.EntityFrameworkCore;

namespace Customers.Models
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionBuilder);
            }
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Customer>().ToTable("Product").HasKey(t => t.Id);

        //    base.OnModelCreating(builder);
        //}

        private string GetStringConectionConfig()
        {
            return @"Server=(localdb)\mssqllocaldb;Database=micro_custumer;Integrated Security=False;Encrypt=false;TrustServerCertificate=false";
        }
    }
}
