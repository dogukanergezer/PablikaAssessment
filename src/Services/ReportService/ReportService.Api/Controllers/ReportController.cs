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
        IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;

        }


        [HttpPost]
        public async Task<IActionResult> AddNewReport(ReportDto reportDto)
        {
            Guid Id = Guid.NewGuid();
            reportDto.Id = Id;
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
        public List<ReportDto> GetReports()
        {
            List<ReportDto> reports = _reportService.GetReports();
            return reports;
        }

        [HttpDelete]
        public void DeleteReport(ReportDto reportDto)
        {
            _reportService.DeleteReport(reportDto.Id);
        }
    }
}
