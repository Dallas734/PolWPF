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
    public class DoctorService : IDoctorService
    {
        IDbRepository dbContext;

        public DoctorService(IDbRepository repository)
        {
            dbContext = repository;
        }
        public List<DoctorDTO> GetDoctorsOnWork()
        {
            return new List<DoctorDTO>();
        }
        public List<DoctorDTO> GetDoctorsOnArea(short area_id)
        {
            return new List<DoctorDTO>();
        }
    }
}
