using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PatientDTO
    {
        public PatientDTO()
        {
        }

        public PatientDTO(Patient p)
        {
            Id = p.Id;
            LastName = p.LastName;
            FirstName = p.FirstName;
            Surname = p.Surname;
            FullName = p.LastName + " " + p.FirstName + " " + p.Surname;
            Gender = p.Gender;
            DateOfBirth = p.DateOfBirth;
            Address_id = p.Address_id;
            Polis = p.Polis;
            WorkPlace = p.WorkPlace;
        }

        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Address_id { get; set; }

        public string Polis { get; set; }

        public string WorkPlace { get; set; }

    }
}
