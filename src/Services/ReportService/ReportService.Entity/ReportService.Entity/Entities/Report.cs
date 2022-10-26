using ReportService.Entity.Entities.Base;
using ReportService.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Entity.Entities
{
    public class Report:BaseEntity
    {
        public string ReportName { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneCount { get; set; }
        public DateTime RequestedDate { get; set; }

        public ReportEnum status { get; set; }
    }
}
