using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IPatientService
    {
        int GetPatientArea(int patient_id);
        List<PatientDTO> GetPatientsOnArea(int area_id);

        List<VisitDTO> GetPatientCard(PatientDTO patient);
    }
}
