using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class SheduleReport
    {
        public string DayName { get; set; }
        public TimeSpan? BeginTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }

    public class VisitReport
    {
        public int Patient_id { get; set; }
        public int? Diagnosis_id { get; set; }
        public string Recipe { get; set; }
        public int? Procedure_id { get; set; }
        public DateTime? DateT { get; set; }
        public TimeSpan? TimeT { get; set; }
    }

    public class PatientCardReport
    {
        public short Patient_id { get; set; }
        public short Doctor_id { get; set; }
        public short Specialization_id { get; set; }
        public DateTime? DateT { get; set; }
        public short Diagnosis_id { get; set; }
    }
}
