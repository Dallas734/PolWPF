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
    public class CertificateRepositorySQL : IRepository<Certificate>
    {
        private PolyclinicContext dbContext;

        public CertificateRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Certificate> GetList()
        {
            return dbContext.Certificate.ToList();
        }
        public IEnumerable<Certificate> GetAll()
        {
            return dbContext.Certificate;
        }

        public void Update(Certificate certificate)
        {
            dbContext.Entry(certificate).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Certificate certificate = dbContext.Certificate.Find(id);
            if (certificate != null)
            {
                dbContext.Certificate.Remove(certificate);
            }
        }
        public Certificate GetItem(int id)
        {
            return dbContext.Certificate.Find(id);
        }
        public void Create(Certificate certificate)
        {
            dbContext.Certificate.Add(certificate);
        }
        public void Load()
        {
            dbContext.Certificate.Load();
        }
        public void Include(string nameOfTable)
        {
            dbContext.Certificate.Include(nameOfTable);
        }
    }
}
