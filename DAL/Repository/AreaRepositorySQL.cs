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
    public class AreaRepositorySQL : IRepository<Area>
    {
        private PolyclinicContext dbContext;

        public AreaRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Area> GetList()
        {
            return dbContext.Area.ToList();
        }
        public IEnumerable<Area> GetAll()
        {
            return dbContext.Area;
        }

        public void Add(Area area) { }
        public void Update(Area area) { }
        public void Delete(int id) { }
        public Area GetItem(int id) { return null; }
        public void Create(Area day) { }
        public void Load()
        {
            dbContext.Area.Load();
        }
        public void Include(string nameOfTable)
        {
            dbContext.Area.Include(nameOfTable);
        }
    }
}
