using DAL.Entities.ReportEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.ReportModels
{
    public class WorkloadReportModel
    {
        public WorkloadReportModel(WorkloadReport report)
        {
            DoctorFIO = report.DoctorFIO;
            Workload = report.Workload;
        }

        public string DoctorFIO { get; set; }

        public string Workload { get; set; }
    }
}
