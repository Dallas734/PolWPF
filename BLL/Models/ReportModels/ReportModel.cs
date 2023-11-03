using DAL.Entities.ReportEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.ReportModels
{
    public class ReportModel
    {
        public ReportModel(Report report)
        {
            Name = report.Name;
            Workload = report.Workload;
        }

        public string Name { get; set; }

        public double Workload { get; set; }
    }
}
