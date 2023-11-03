using DAL.Entities;
using DAL.Entities.ReportEntities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ReportRepositorySQL : IReportRepository
    {
        private PolyclinicContext dbContext;

        public ReportRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<WorkloadReport> MakeWorkLoadReport(int area_id)
        {
            List<WorkloadReport> report = new List<WorkloadReport>();

            int count = dbContext.Visit.Join(dbContext.Doctor, v => v.Doctor_id, d => d.Id, (v, d) => d)
                .Where(d => d.Area_id == area_id)
                .Count();

            List<Doctor> doctors = dbContext.Doctor.Where(d => d.Area_id == area_id).ToList();

            foreach(Doctor doctor in doctors)
            {
                int doctorVisitCount = dbContext.Visit.Join(dbContext.Doctor, v => v.Doctor_id, d => d.Id, (v, d) => d)
                .Where(d => d.Id == doctor.Id)
                .Count();

                double workload = doctorVisitCount / count;

                report.Add(new WorkloadReport()
                {
                    DoctorFIO = doctor.LastName + " " + doctor.FirstName + " " + doctor.Surname,
                    Workload = workload
                });
            }

            return report;
        }
    }
}
