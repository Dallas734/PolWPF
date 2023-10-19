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
    public class SpecializationRepositorySQL : IRepository<Specialization>
    {
        private PolyclinicContext dbContext;

        public SpecializationRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Specialization> GetList()
        {
            return dbContext.Specialization.ToList();
        }
        public IEnumerable<Specialization> GetAll()
        {
            return dbContext.Specialization;
        }

        public void Update(Specialization specialization) 
        { 
            dbContext.Entry(specialization).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Specialization specialization = dbContext.Specialization.Find(id);
            if (specialization != null)
                dbContext.Specialization.Remove(specialization);
        }
        public Specialization GetItem(int id)
        {
            return dbContext.Specialization.Find(id); 
        }
        public void Create(Specialization specialization)
        {
            dbContext.Specialization.Add(specialization);
        }
        public void Load()
        {
            dbContext.Specialization.Load();
        }
        public void Include(string nameOfTable)
        {
            dbContext.Specialization.Include(nameOfTable);
        }
    }
}
