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

        public List<Report> MakeWorkLoadReport(int area_id, DateTime begin, DateTime end)
        {
            if (begin > end)
                throw new Exception("Начальная дата не должна быть больше конечной!");

            double workload;
            List<Report> report = new List<Report>();

            int count = dbContext.Visit
                .Where(v => v.DateT >= begin && v.DateT <= end)
                .Join(dbContext.Doctor, v => v.Doctor_id, d => d.Id, (v, d) => d)
                .Where(d => d.Area_id == area_id)
                .Count();

            List<Doctor> doctors = dbContext.Doctor.Where(d => d.Area_id == area_id).ToList();

            foreach(Doctor doctor in doctors)
            {
                int doctorVisitCount = dbContext.Visit
                    .Where(v => v.DateT >= begin && v.DateT <= end)
                    .Join(dbContext.Doctor, v => v.Doctor_id, d => d.Id, (v, d) => d)
                    .Where(d => d.Id == doctor.Id)
                    .Count();

                if (count == 0)
                    workload = 0;
                else workload = Math.Round((double)doctorVisitCount / count, 2);

                report.Add(new Report()
                {
                    Name = doctor.LastName + " " + doctor.FirstName + " " + doctor.Surname,
                    Workload = workload   
                });
            }

            return report;
        }

        public List<Report> MakeDiagnosisReport(int doctor_id, DateTime begin, DateTime end)
        {
            if (begin > end)
                throw new Exception("Начальная дата не должна быть больше конечной!");

            double workload;
            List<Report> report = new List<Report>();

            int count = dbContext.Visit.Where(i => i.Doctor_id == doctor_id && i.VisitStatus_id == 2 && i.DateT >= begin && i.DateT <= end).Count();
            List<int> diagnosis_ids = dbContext.Visit.Where(i => i.Doctor_id == doctor_id && i.VisitStatus_id == 2 && i.DateT >= begin && i.DateT <= end).
                Select(i => (int)i.Diagnosis_id).Distinct().ToList();

            foreach(int id in diagnosis_ids)
            {
                int diagnosisCount = dbContext.Visit.Where(i => i.Doctor_id == doctor_id && i.VisitStatus_id == 2 && i.Diagnosis_id == id && i.DateT >= begin && i.DateT <= end).Count();
                if (count == 0)
                    workload = 0;
                else workload = Math.Round((double)diagnosisCount / count, 2);

                report.Add(new Report()
                {
                    Name = dbContext.Diagnosis.Where(i => i.Id == id).FirstOrDefault().Name,
                    Workload = workload
                });
            }

            return report;
        }
    }
}
