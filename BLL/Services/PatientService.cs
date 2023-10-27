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
    public class PatientService : IPatientService
    {
        IDbRepository dbContext;

        public PatientService(IDbRepository repository)
        {
            dbContext = repository;
        }

        public int GetPatientArea(int patient_id)
        {
            return 1;
        }
        public List<PatientDTO> GetPatientsOnArea(int area_id)
        {
            return dbContext.Patients.GetAll().Join(dbContext.Addresses.GetAll().Where(a => a.Area_id == area_id), p => p.Address_id, a => a.Id, (p, a) => p).Select(i => new PatientDTO(i)).ToList();
        }

        public List<VisitDTO> GetPatientCard(PatientDTO patient)
        {
            return dbContext.Visits.GetAll().Where(i => i.Patient_id == patient.Id && i.VisitStatus_id == 2).Select(i => new VisitDTO(i)).ToList();
        }
    }
}
