using EventBus.RabbitMQ;
using EventBus.RabbitMQ.Models;
using MassTransit;
using Newtonsoft.Json;
using ReportService.Data.Contexts;
using ReportService.Entity.DTOs;
using ReportService.Entity.Enums;
using RestSharp;

namespace ReportService.Api.Events
{
    public class ReportConsumer : IConsumer<IReportConsumer>
    {
        public ReportConsumer()
        {
            var bus = BusConfigurator.ConfigureBus(factory =>
            {
                factory.ReceiveEndpoint(RabbitMqConstants.ConsumerQueue, endpoint =>
                {
                    endpoint.Consumer<ReportConsumer>();
                });
            });

            bus.StartAsync();
        }
        public async Task Consume(ConsumeContext<IReportConsumer> context)
        {

            Console.WriteLine($"The report has been saved in the database.");

            using (var reportContext = new ReportServiceContext())
            {
                var report = reportContext.Reports.FirstOrDefault(x => x.Id == context.Message.ID);

                if (report != null)
                {
                    var client = new RestClient("http://localhost:5000/contact/createReport");
                    var request = new RestRequest("",Method.Post);
                    request.AddHeader("Content-Type", "application/json");
                    var data = new AddressDto();
                    data.Address = report.Location;
                    request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
                    RestResponse response = client.Execute(request);
                    var responsedata = JsonConvert.DeserializeObject<ReportInfoFromUserDto>(response.Content);
                    report.PhoneCount = responsedata.PhoneCount;
                    report.PersonCount = responsedata.UserCount;
                    report.status =ReportEnum.Completed;
                    reportContext.Reports.Update(report);
                    await reportContext.SaveChangesAsync();
                }
            }
        }
    }

}
