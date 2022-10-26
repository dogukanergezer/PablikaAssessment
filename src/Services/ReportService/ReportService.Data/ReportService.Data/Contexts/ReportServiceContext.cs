using Microsoft.EntityFrameworkCore;
using ReportService.Entity.Entities;

namespace ReportService.Data.Contexts
{
    public class ReportServiceContext:DbContext
    {
        public DbSet<Report> Reports { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=PablikaReportServiceDb;Integrated Security=true; User Id=postgres;Password=0000;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>().ToTable("Report", "public");
        }
    }
}
