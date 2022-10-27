using Microsoft.EntityFrameworkCore;
using ReportService.Entity.Entities;

namespace ReportService.Data.Contexts
{
    public class ReportServiceContext:DbContext
    {
        public DbSet<Report> Reports { get; set; }

        public ReportServiceContext(DbContextOptions<ReportServiceContext> options) : base(options) { }

        public ReportServiceContext()
        {
        }
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
