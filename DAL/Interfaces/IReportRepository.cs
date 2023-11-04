using DAL.Entities.ReportEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IReportRepository
    {
        List<Report> MakeWorkLoadReport(int area_id);
        List<Report> MakeDiagnosisReport(int doctor_id);
    }
}
