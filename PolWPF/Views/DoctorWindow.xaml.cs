using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL.Interfaces;
using PolWPF.ViewModels;

namespace PolWPF
{
    /// <summary>
    /// Логика взаимодействия для DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public DoctorWindow(IDbCrud dbCrud, IComboService comboService, IPatientService patientService, IReportService reportService, IVisitService visitService, ISheduleService sheduleService, IFileService fileService)
        {
            InitializeComponent();

            DataContext = new DoctorViewModel(this, dbCrud, comboService, patientService, reportService, visitService, sheduleService, fileService);
        }
    }
}
