using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ReportRepositorySQL : IReportRepository
    {
        private PolyclinicContext dbContext;

        public ReportRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }


    }
}
