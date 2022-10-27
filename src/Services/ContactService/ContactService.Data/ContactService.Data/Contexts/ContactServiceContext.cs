using ContactService.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Data.Contexts
{
    public class ContactServiceContext : DbContext
    {
        public ContactServiceContext()
        {
        }

        public ContactServiceContext(DbContextOptions<ContactServiceContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
    }
}
