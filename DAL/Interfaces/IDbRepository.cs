using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDbRepository
    {
        IRepository<Doctor> Doctors { get; }
        IRepository<Visit> Visits { get; }
        IRepository<Shedule> Shedules { get; }
        IRepository<Day> Days { get; }
        IRepository<Patient> Patients { get; }
        IRepository<Address> Addresses { get; }
        IRepository<Area> Areas { get; }
        IRepository<Diagnosis> Diagnosises { get; }
        IRepository<Procedure> Procedures { get; }
        IRepository<Specialization> Specializations { get; }
        IRepository<Status> Statuses { get; }
        IRepository<Category> Categories { get; }
        int Save();
    }
}
