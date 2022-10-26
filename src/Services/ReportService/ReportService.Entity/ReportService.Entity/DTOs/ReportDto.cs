using ReportService.Entity.Enums;

namespace ReportService.Entity.DTOs
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public string ReportName { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }

        public int PhoneCount { get; set; }
        public DateTime RequestedDate { get; set; }
        public ReportEnum status { get; set; }
    }
}
