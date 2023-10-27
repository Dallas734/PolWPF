using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class VisitService : IVisitService
    {
        enum Days
        {
            
        }

        IDbRepository dbContext;

        public VisitService(IDbRepository repository)
        {
            dbContext = repository;
        }

        public bool CheckVisitAvailable(VisitDTO visit)
        {
            return true; 
        }

        public List<Talon> GetTalons(DoctorDTO doctor, DateTime date)
        {
            List<Talon> talons = new List<Talon>();
            TimeSpan? beginTime = dbContext.Shedules.GetAll().Where(i => i.Doctor_id == doctor.Id && i.Day_id == (int)date.DayOfWeek).FirstOrDefault().BeginTime;
            TimeSpan? endTime = dbContext.Shedules.GetAll().Where(i => i.Doctor_id == doctor.Id && i.Day_id == (int)date.DayOfWeek).FirstOrDefault().EndTime;

            while (beginTime <= endTime)
            {
                Talon talon = new Talon();
                talon.Time = beginTime.Value;
                talon.Date = date;
                if (dbContext.Visits.GetAll().Where(i => i.TimeT == talon.Time && i.DateT == date.Date && i.VisitStatus.Id == 1 && i.Doctor_id == doctor.Id).FirstOrDefault() != null)
                {
                    VisitDTO visitDTO = new VisitDTO(dbContext.Visits.GetAll().Where(i => i.TimeT == talon.Time && i.DateT == date && i.VisitStatus.Id == 1 && i.Doctor_id == doctor.Id).FirstOrDefault());
                    talon.Visit = visitDTO;
                    talon.Status = "Занято";
                }

                talons.Add(talon);
                beginTime = new TimeSpan(beginTime.Value.Ticks + TimeSpan.FromMinutes(30).Ticks);
            }

            return talons;
        }

        public List<VisitDTO> GetFutureVisitsOnPatientAndDate(PatientDTO patient, DateTime date)
        {
            return dbContext.Visits.GetList().Where(
                          i => i.Patient_id == patient.Id && i.DateT == date.Date && i.VisitStatus_id == 1).Select(i => new VisitDTO(i)).ToList();
        }
    }
}
