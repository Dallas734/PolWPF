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
            DateOfBirth = d.DateOfBirth;
            Status_id = d.Status_id;
            Area_id = d.Area_id;
            Category_id = d.Category_id;
            FullName = d.LastName + " " + d.FirstName + " " + d.Surname;
        }

        public short Id { get; set; }

        public short Specialization_id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public short Status_id { get; set; }

        public short? Area_id { get; set; }

        public short Category_id { get; set; }

        public int Age { get; set; }

    }
}
