using ReportService.Entity.Enums;

namespace EventBus.RabbitMQ.Models
{
    public interface IReportConsumer
    {
        Guid ID { get; set; }
        string ReportName { get; set; }
        string Location { get; set; }
        int PersonCount { get; set; }

        int PhoneCount { get; set; }
        DateTime RequestedDate { get; set; }
        string CreatedDate { get; set; }

        ReportEnum status { get; set; }
    }
}
