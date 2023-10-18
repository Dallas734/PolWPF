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
    public class VisitRepositorySQL : IRepository<Visit>
    {
        private PolyclinicContext dbContext;

        public VisitRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Visit> GetList()
        {
            return dbContext.Visit.ToList();
        }

        public IEnumerable<Visit> GetAll()
        {
            return dbContext.Visit;
        }
        public Visit GetItem(int id)
        {
            return dbContext.Visit.Find(id);
        }
        public void Create(Visit item)
        {
            dbContext.Visit.Add(item);
        }
        public void Update(Visit item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Visit visit = dbContext.Visit.Find(id);
            if (visit != null)
            {
                dbContext.Visit.Remove(visit);
            }
        }
        public void Load()
        {
            dbContext.Visit.Load();
        }
        public void Include(string nameOfTable)
        {
            dbContext.Visit.Include(nameOfTable);
        }
    }
}
