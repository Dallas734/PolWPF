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

        public short GetPatientArea(short patient_id)
        {
            return 1;
        }
        public List<PatientDTO> GetPatientsOnArea(short area_id)
        {
            return new List<PatientDTO>();
        }
    }
}
