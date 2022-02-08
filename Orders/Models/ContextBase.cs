using Microsoft.EntityFrameworkCore;

namespace Orders.Models
{
    public class ContextBase : DbContext 
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if(!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>().ToTable("Order").HasKey(t => t.Id);
            builder.Entity<Customer>().ToTable("ORDER_Customer").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        private string GetStringConectionConfig()
        {
            return @"Server=(localdb)\mssqllocaldb;Database=micro_order;Integrated Security=False;Encrypt=false;TrustServerCertificate=false";
        }
    }
}
