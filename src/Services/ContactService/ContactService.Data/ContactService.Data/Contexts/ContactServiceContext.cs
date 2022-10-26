using ContactService.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Data.Contexts
{
    public class ContactServiceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=PablikaContactServiceDb;Integrated Security=true; User Id=postgres;Password=0000;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User", "public");
            modelBuilder.Entity<Contact>().ToTable("Contact", "public");
        }
    }
}
