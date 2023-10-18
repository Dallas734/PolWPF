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
    public class PatientRepositorySQL : IRepository<Patient>
    {
        private PolyclinicContext dbContext;

        public PatientRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Patient> GetList()
        {
            return dbContext.Patient.ToList();
        }
        public IEnumerable<Patient> GetAll()
        {
            return dbContext.Patient;
        }
        public Patient GetItem(int id)
        {
            return dbContext.Patient.Find(id);
        }
        public void Create(Patient item)
        {
            dbContext.Patient.Add(item);
        }
        public void Update(Patient item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Patient patient = dbContext.Patient.Find(id);
            if (patient != null)
            {
                dbContext.Patient.Remove(patient);
            }
        }
        public void Load()
        {
            dbContext.Patient.Load();
        }

        public void Include(string nameOfTable)
        {
            dbContext.Patient.Include(nameOfTable);
        }
    }
}
