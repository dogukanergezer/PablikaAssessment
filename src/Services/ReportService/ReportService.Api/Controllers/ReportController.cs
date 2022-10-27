using EventBus.RabbitMQ;
using EventBus.RabbitMQ.Models;
using Microsoft.AspNetCore.Mvc;
using ReportService.Business.Abstract;
using ReportService.Entity.DTOs;

namespace ReportService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;

        }


        [HttpPost]
        public async Task<IActionResult> AddNewReport(ReportDto reportDto)
        {
            reportDto.Id = Guid.NewGuid(); 
            reportDto.ReportName = reportDto.ReportName;
            reportDto.RequestedDate = DateTime.Now;
            reportDto.Location = reportDto.Location;
            _reportService.AddReport(reportDto);


            var bus = BusConfigurator.ConfigureBus();
            var sendToUri = new Uri($"{RabbitMqConstants.RabbitMqUri}/{RabbitMqConstants.ConsumerQueue}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);
            await endPoint.Send<IReportConsumer>(reportDto);
            return Ok("Your report request has been received ");

        }

        [HttpGet]
        public List<ReportDto> GetReports() => _reportService.GetReports();


        [HttpDelete]
        public void DeleteReport(ReportDto reportDto)
        {
            _reportService.DeleteReport(reportDto.Id);
        }
    }
}
