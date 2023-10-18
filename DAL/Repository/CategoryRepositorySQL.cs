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
    public class CategoryRepositorySQL : IRepository<Category>
    {
        private PolyclinicContext dbContext;

        public CategoryRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Category> GetList()
        {
            return dbContext.Category.ToList();
        }
        public IEnumerable<Category> GetAll()
        {
            return dbContext.Category;
        }

        public void Add(Category category) { }
        public void Update(Category category) { }
        public void Delete(int id) { }
        public Category GetItem(int id) { return null; }
        public void Create(Category category) { }
        public void Load()
        {
            dbContext.Category.Load();
        }
        public void Include(string nameOfTable)
        {
            dbContext.Category.Include(nameOfTable);
        }
    }
}
