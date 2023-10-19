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
        short GetPatientArea(short patient_id);
        List<PatientDTO> GetPatientsOnArea(short area_id);
    }
}
