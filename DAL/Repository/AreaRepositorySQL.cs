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

        public void Update(Area area) 
        { 
            dbContext.Entry(area).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Area area = dbContext.Area.Find(id);
            if (area != null)
            {
                dbContext.Area.Remove(area);
            }
        }
        public Area GetItem(int id) 
        {
            return dbContext.Area.Find(id); 
        }
        public void Create(Area area) 
        { 
            dbContext.Area.Add(area);
        }
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
