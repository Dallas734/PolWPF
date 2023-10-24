using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class DiagnosisDTO
    {
        public DiagnosisDTO()
        {
        }

        public DiagnosisDTO(Diagnosis d)
        {
            Id = d.Id;
            Name = d.Name;
        }
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
