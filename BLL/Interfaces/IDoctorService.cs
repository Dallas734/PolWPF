using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDoctorService
    {
        List<DoctorDTO> GetDoctorsOnWork(List<DoctorDTO> doctors);
        List<DoctorDTO> GetDoctorsOnAreaAndSpecialization(int area_id, int spec_id);
    }
}
