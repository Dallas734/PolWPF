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
    public class DiagnosisRepositorySQL : IRepository<Diagnosis>
    {
        private PolyclinicContext dbContext;

        public DiagnosisRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Diagnosis> GetList()
        {
            return dbContext.Diagnosis.ToList();
        }
        public IEnumerable<Diagnosis> GetAll()
        {
            return dbContext.Diagnosis;
        }

        public void Update(Diagnosis diagnosis) 
        {
            dbContext.Entry(diagnosis).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Diagnosis diagnosis = dbContext.Diagnosis.Find(id);
            if (diagnosis != null)
                dbContext.Diagnosis.Remove(diagnosis);
        }
        public Diagnosis GetItem(int id) 
        { 
            return dbContext.Diagnosis.Find(id);
        }
        public void Create(Diagnosis diagnosis)
        {
            dbContext.Diagnosis.Add(diagnosis);
        }
        public void Load()
        {
            dbContext.Diagnosis.Load();
        }
        public void Include(string nameOfTable)
        {
            dbContext.Diagnosis.Include(nameOfTable);
        }
    }
}
