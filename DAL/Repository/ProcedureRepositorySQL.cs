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
    public class ProcedureRepositorySQL : IRepository<Procedure>
    {
        private PolyclinicContext dbContext;

        public ProcedureRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Procedure> GetList()
        {
            return dbContext.Procedure.ToList();
        }
        public IEnumerable<Procedure> GetAll()
        {
            return dbContext.Procedure;
        }

        public void Update(Procedure procedure)
        { 
            dbContext.Entry(procedure).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Procedure procedure = dbContext.Procedure.Find(id);
            if (procedure != null)
                dbContext.Procedure.Remove(procedure);
        }
        public Procedure GetItem(int id) 
        { 
            return dbContext.Procedure.Find(id); 
        }
        public void Create(Procedure procedure)
        {
            dbContext.Procedure.Add(procedure);
        }
        public void Load()
        {
            dbContext.Procedure.Load();
        }
        public void Include(string nameOfTable)
        {
            dbContext.Procedure.Include(nameOfTable);
        }
    }
}
