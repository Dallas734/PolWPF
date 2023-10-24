using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class VisitDTO
    {
        public VisitDTO() { }

        public VisitDTO(Visit v)
        {
            Id = v.Id;
            Patient_id = v.Patient_id;
            Diagnosis_id = v.Diagnosis_id;
            Recipe = v.Recipe;
            Procedure_id = v.Procedure_id;
            DateT = v.DateT;
            TimeT = v.TimeT;
            Doctor_id = v.Doctor_id;
        }
        public int Id { get; set; }

        public int Patient_id { get; set; }

        public int? Diagnosis_id { get; set; }

        public string Recipe { get; set; }

        public int? Procedure_id { get; set; }

        public DateTime DateT { get; set; }

        public TimeSpan TimeT { get; set; }

        public int? Doctor_id { get; set; }

    }
}
