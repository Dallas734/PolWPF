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
    public class GenderRepositorySQL : IRepository<Gender>
    {
        private PolyclinicContext dbContext;

        public GenderRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Gender> GetList()
        {
            return dbContext.Gender.ToList();
        }
        public IEnumerable<Gender> GetAll()
        {
            return dbContext.Gender;
        }

        public void Update(Gender gender)
        {
            dbContext.Entry(gender).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Gender gender = dbContext.Gender.Find(id);
            if (gender != null)
                dbContext.Gender.Remove(gender);
        }
        public Gender GetItem(int id)
        {
            return dbContext.Gender.Find(id);
        }
        public void Create(Gender gender)
        {
            dbContext.Gender.Add(gender);
        }

        public void Load()
        {
            dbContext.Gender.Load();
        }
        public void Include(string nameOfTable)
        {
            dbContext.Gender.Include(nameOfTable);
        }
    }
}
