using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DoctorRepositorySQL : IRepository<Doctor>
    {
        private PolyclinicContext dbContext;

        public DoctorRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Doctor> GetList()
        {
            return dbContext.Doctor.ToList();
        }

        public IEnumerable<Doctor> GetAll()
        {
            return dbContext.Doctor;
        }
        public Doctor GetItem(int id)
        {
            return dbContext.Doctor.Find(id);
        }
        public void Create(Doctor item)
        {
            dbContext.Doctor.Add(item);
        }
        public void Update(Doctor item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Doctor doctor = dbContext.Doctor.Find(id);
            if (doctor != null)
            {
                dbContext.Doctor.Remove(doctor);
            }
        }
        public void Load()
        {
            dbContext.Doctor.Load();
        }

        public void Include(string nameOfTable)
        {
            dbContext.Doctor.Include(nameOfTable);
        }
    }
}
