using Microsoft.EntityFrameworkCore;

namespace TermProject.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Season> Seasons { get; set; } = null!;
        public DbSet<Designer> Designers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Designer>().HasData(
                new Designer { DesignerId = 1, FirstName = "Elia", LastName = "Schall", Email = "eschall@calliopezoisite.com"},
                new Designer { DesignerId = 2, FirstName = "Romy", LastName = "Linder", Email = "rlinder@calliopezoisite.com" },
                new Designer { DesignerId = 3, FirstName = "Hugo", LastName = "Karlen", Email = "hkarlen@calliopezoisite.com" },
                new Designer { DesignerId = 4, FirstName = "Elinora", LastName = "Felix", Email = "efelix@calliopezoisite.com" },
                new Designer { DesignerId = 5, FirstName = "Tessa", LastName = "Abeline", Email = "tabeline@calliopezoisite.com" },
                new Designer { DesignerId = 6, FirstName = "CRUD", LastName = "Testing", Email = "ugh@test.org"});

            modelBuilder.Entity<Season>().HasData(
                new Season { SeasonId = "S", Name = "Spring/Summer" },
                new Season { SeasonId = "F", Name = "Fall/Winter" });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Caviar Dreams Asymmetrical",
                    Type = "Skirt",
                    Year = 2022,
                    SeasonId = "S"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Effervescent Halter Wrap",
                    Type = "Top",
                    Year = 2022,
                    SeasonId = "F"      
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Nephilim Winged Bomber",
                    Type = "Jacket",
                    Year = 2023,
                    SeasonId = "F"
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Counterculture Bootcut",
                    Type = "Pants",
                    Year = 2024,
                    SeasonId = "S"
                },
                new Product
                {
                    ProductId = 5,
                    Name = "File Not Found Cardigan",
                    Type = "Jacket",
                    Year = 2024,
                    SeasonId = "F"
                });
        }
    }
}
