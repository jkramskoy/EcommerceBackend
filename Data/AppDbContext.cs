using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public DbSet<Product> Products { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseMySQL(@"server=localhost;user=root;password=amy251202;database=backend;");
        base.OnConfiguring(optionsBuilder);
    }
}