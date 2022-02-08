using Microsoft.EntityFrameworkCore;

namespace Products.Models
{
    public class ContextBase : DbContext 
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Variation> Variation { get; set; }

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
            builder.Entity<Product>().ToTable("Product").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        private string GetStringConectionConfig()
        {
            return @"Server=(localdb)\mssqllocaldb;Database=micro_product;Integrated Security=False;Encrypt=false;TrustServerCertificate=false";
        }
    }
}
