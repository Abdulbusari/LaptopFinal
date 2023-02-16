using LaptopFinal.Models;
using Microsoft.EntityFrameworkCore;

public class LaptopVendorDbContext : DbContext
{
    public LaptopVendorDbContext(DbContextOptions<LaptopVendorDbContext> options) : base(options)
    {
    }

    public DbSet<Laptop> Laptops { get; set; }
}
