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

        public void Add(Specialization specialization) { }
        public void Update(Specialization specialization) { }
        public void Delete(int id) { }
        public Specialization GetItem(int id) { return null; }
        public void Create(Specialization specialization) { }
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
