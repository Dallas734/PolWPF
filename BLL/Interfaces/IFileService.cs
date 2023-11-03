using BLL.Models.ReportModels;
using DAL.Entities.ReportEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFileService
    {
        void Save (string filename, List<ReportModel> data, string header);
    }
}
