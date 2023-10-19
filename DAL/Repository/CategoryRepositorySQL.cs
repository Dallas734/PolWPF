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

        public void Update(Category category) 
        { 
            dbContext.Entry(category).State = EntityState.Modified;
        }
        public void Delete(int id)
        { 
           Category category = dbContext.Category.Find(id);
            if (category != null)
                dbContext.Category.Remove(category);
        }
        public Category GetItem(int id)
        {
            return dbContext.Category.Find(id); 
        }
        public void Create(Category category)
        { 
            dbContext.Category.Add(category);
        }
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
