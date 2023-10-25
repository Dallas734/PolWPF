using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class DoctorDTO
    {
        public DoctorDTO()
        {
        }
        public DoctorDTO(Doctor d)
        {
            Id = d.Id;
            Specialization_id = d.Specialization_id;
            LastName = d.LastName;
            FirstName = d.FirstName;
            Surname = d.Surname;
            Gender_id = d.Gender_id;
            DateOfBirth = d.DateOfBirth;
            Status_id = d.Status_id;
            Area_id = d.Area_id;
            Category_id = d.Category_id;
            FullName = d.LastName + " " + d.FirstName + " " + d.Surname;
        }

        public int Id { get; set; }

        public int Specialization_id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Status_id { get; set; }

        public int? Area_id { get; set; }

        public int Category_id { get; set; }

        public int? Gender_id { get; set; }
    }
}
