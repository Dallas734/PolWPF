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
    public class AddressRepositorySQL : IRepository<Address>
    {
        private PolyclinicContext dbContext;

        public AddressRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Address> GetList()
        {
            return dbContext.Address.ToList();
        }
        public IEnumerable<Address> GetAll()
        {
            return dbContext.Address;
        }

        public void Update(Address address) 
        {
            dbContext.Entry(address).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Address address = dbContext.Address.Find(id);
            if (address != null)
            {
                dbContext.Address.Remove(address);
            }
        }
        public Address GetItem(int id) 
        {
            return dbContext.Address.Find(id);
        }
        public void Create(Address address) 
        {
            dbContext.Address.Add(address);
        }
        public void Load()
        {
            dbContext.Address.Load();
        }
        public void Include(string nameOfTable)
        {
            dbContext.Address.Include(nameOfTable);
        }
    }
}
