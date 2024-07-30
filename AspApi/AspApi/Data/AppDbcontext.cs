using Microsoft.EntityFrameworkCore;

namespace AspApi.Data
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext(DbContextOptions options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("Products");
        }
    }
}
