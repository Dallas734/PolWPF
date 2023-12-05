using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PatientDTO : INotifyPropertyChanged
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
            Gender_id = p.Gender_id;
            DateOfBirth = p.DateOfBirth;
            Address_id = (int)p.Address_id;
            Polis = p.Polis;
            WorkPlace = p.WorkPlace;
        }

        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Address_id { get; set; }

        public string Polis { get; set; }

        public string WorkPlace { get; set; }

        public int? Gender_id {  get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
