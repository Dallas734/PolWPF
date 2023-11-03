using BLL.Models.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IReportService
    {
        List<WorkloadReportModel> MakeWorkloadReport(int area_id);
    }
}
