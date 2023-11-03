using Ninject.Modules;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Services;

namespace PolWPF.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbCrud>().To<DbDataOperations>();
            Bind<IComboService>().To<ComboService>();
            Bind<IDoctorService>().To<DoctorService>();
            Bind<IPatientService>().To<PatientService>();
            Bind<IReportService>().To<ReportService>();
            Bind<ISheduleService>().To<SheduleService>();
            Bind<IVisitService>().To<VisitService>();
            Bind<IFileService>().To<FileService>();
        }
    }
}
