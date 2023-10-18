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

        public void Add(Status status) { }
        public void Update(Status status) { }
        public void Delete(int id) { }
        public Status GetItem(int id) { return null; }
        public void Create(Status status) { }
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
