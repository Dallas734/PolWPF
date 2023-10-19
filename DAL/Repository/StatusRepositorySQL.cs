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
    public class StatusRepositorySQL : IRepository<Status>
    {
        private PolyclinicContext dbContext;

        public StatusRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Status> GetList()
        {
            return dbContext.Status.ToList();
        }
        public IEnumerable<Status> GetAll()
        {
            return dbContext.Status;
        }

        public void Update(Status status)
        {
            dbContext.Entry(status).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Status status = dbContext.Status.Find(id);
            if (status != null)
            {
                dbContext.Status.Remove(status);
            }
        }
        public Status GetItem(int id)
        { 
            return dbContext.Status.Find(id);
        }
        public void Create(Status status) 
        {
            dbContext.Status.Add(status);
        }
        public void Load()
        {
            dbContext.Status.Load();
        }
        public void Include(string nameOfTable)
        {
            dbContext.Status.Include(nameOfTable);
        }
    }
}
