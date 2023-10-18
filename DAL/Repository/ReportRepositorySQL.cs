using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ReportRepositorySQL
    {
        private PolyclinicContext dbContext;

        public ReportRepositorySQL(PolyclinicContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
