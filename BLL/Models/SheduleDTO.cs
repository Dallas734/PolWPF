using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class SheduleDTO
    {
        public SheduleDTO() { }
        public SheduleDTO(Shedule s)
        {
            Id = s.Id;
            Day_id = s.Day_id;
            Doctor_id = s.Doctor_id;
            BeginTime = s.BeginTime;
            EndTime = s.EndTime;
        }
        public short Id { get; set; }

        public short Day_id { get; set; }

        public short Doctor_id { get; set; }

        public TimeSpan? BeginTime { get; set; }

        public TimeSpan? EndTime { get; set; }

    }
}
