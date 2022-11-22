using LoL.Data.Enities;

namespace LoL.Data
{
    internal class AppDbContext:DbContext
    {
        DbSet<Champion> Champions { get; set; }
        DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=LoLDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Role> roles = new List<Role>
            {
                    new Role {Id = 1, Name = "Top" },
                    new Role {Id = 2,  Name = "Middle" } ,
                    new Role {Id = 3,  Name = "Adc" },
                    new Role {Id = 4,  Name = "Jungle" },
                    new Role {Id = 5,  Name = "Support" }
            };

            modelBuilder.Entity<Role>().HasData(roles);
        }
    }
}
