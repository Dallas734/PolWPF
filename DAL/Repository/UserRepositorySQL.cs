using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepositorySQL : IRepository<User>
    {
        private PolyclinicContext dbContext;

        public UserRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<User> GetList()
        {
            return dbContext.User.ToList();
        }
        public IEnumerable<User> GetAll()
        {
            return dbContext.User;
        }

        public User GetItem(int id) { return null; }
        public void Create(User item) { }
        public void Update(User item) { }
        public void Delete(int id) { }
        public void Load() { }
        public void Include(string nameOfTable) { }
    }
}
