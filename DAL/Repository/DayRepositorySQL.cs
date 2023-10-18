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
    public class DayRepositorySQL : IRepository<Day>
    {
        private PolyclinicContext dbContext;

        public DayRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Day> GetList()
        {
            return dbContext.Day.ToList();
        }
        public IEnumerable<Day> GetAll()
        {
            return dbContext.Day;
        }

        public void Add(Day day) { }
        public void Update(Day day) { }
        public void Delete(int id) { }
        public Day GetItem(int id) { return null; }
        public void Create(Day day) { }

        public void Load()
        {
            dbContext.Day.Load();
        }
        public void Include(string nameOfTable)
        {
            dbContext.Day.Include(nameOfTable);
        }
    }
}
