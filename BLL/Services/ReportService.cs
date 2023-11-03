using BLL.Interfaces;
using BLL.Models.ReportModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReportService : IReportService
    {
        IDbRepository dbContext;

        public ReportService(IDbRepository repos)
        {
            dbContext = repos;
        }

        public List<WorkloadReportModel> MakeWorkloadReport(int area_id)
        {
            return dbContext.Reports.MakeWorkLoadReport(area_id).Select(i => new WorkloadReportModel(i)).ToList();
        }
    }
}
