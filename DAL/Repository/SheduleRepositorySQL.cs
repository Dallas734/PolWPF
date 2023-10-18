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
    public class SheduleRepositorySQL : IRepository<Shedule>
    {
        private PolyclinicContext dbContext;

        public SheduleRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Shedule> GetList()
        {
            return dbContext.Shedule.ToList();
        }
        public IEnumerable<Shedule> GetAll()
        {
            return dbContext.Shedule;
        }
        public Shedule GetItem(int id)
        {
            return dbContext.Shedule.Find(id);
        }
        public void Create(Shedule item)
        {

        }
        public void Update(Shedule item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Shedule shedule = dbContext.Shedule.Find(id);
            if (shedule != null)
            {
                dbContext.Shedule.Remove(shedule);
            }
        }
        public void Load()
        {
            dbContext.Shedule.Load();
        }
        public void Include(string nameOfTable)
        {
            dbContext.Shedule.Include(nameOfTable);
        }
    }
}
