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
    public class SheduleService : ISheduleService
    {
        IDbRepository dbContext;

        public SheduleService(IDbRepository repository)
        {
            dbContext = repository;
        }
        public List<SheduleDTO> GetSheduleOnDoctor(DoctorDTO doctor)
        {
            List<SheduleDTO> times = dbContext.Shedules.GetAll()
              .Join(dbContext.Days.GetAll(), s => s.Day_id, d => d.Id, (s, d) => new {s.Id, DayName = d.Name, s.BeginTime, s.EndTime, s.Doctor_id })
              .Where(o => o.Doctor_id == doctor.Id && o.BeginTime != null && o.EndTime != null)
              .Select(o => new SheduleDTO { newBeginTime = new DateTime(o.BeginTime.Value.Ticks), newEndTime = new DateTime(o.EndTime.Value.Ticks),
                  Id = o.Id, DayName = o.DayName, BeginTime = o.BeginTime, EndTime = o.EndTime })
              .ToList();

            return times;
        }
    }
}
