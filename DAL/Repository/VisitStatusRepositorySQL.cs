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
    public class VisitStatusRepositorySQL : IRepository<VisitStatus>
    {
        private PolyclinicContext dbContext;

        public VisitStatusRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<VisitStatus> GetList()
        {
            return dbContext.VisitStatus.ToList();
        }
        public IEnumerable<VisitStatus> GetAll()
        {
            return dbContext.VisitStatus;
        }

        public void Update(VisitStatus visitStatus)
        {
            dbContext.Entry(visitStatus).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            VisitStatus status = dbContext.VisitStatus.Find(id);
            if (status != null)
            {
                dbContext.VisitStatus.Remove(status);
            }
        }
        public VisitStatus GetItem(int id)
        {
            return dbContext.VisitStatus.Find(id);
        }
        public void Create(VisitStatus status)
        {
            dbContext.VisitStatus.Add(status);
        }
        public void Load()
        {
            dbContext.VisitStatus.Load();
        }
        public void Include(string nameOfTable)
        {
            dbContext.VisitStatus.Include(nameOfTable);
        }
    }
}
