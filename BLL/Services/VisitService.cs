using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class VisitService : IVisitService
    {
        IDbRepository dbContext;

        public VisitService(IDbRepository repository)
        {
            dbContext = repository;
        }

        public bool CheckVisitAvailable(VisitDTO visit)
        {
            return true; 
        }
    }
}
