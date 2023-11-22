using PolWPF.ViewModels;
using BLL.Interfaces;
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

namespace PolWPF
{
    /// <summary>
    /// Логика взаимодействия для RegistratorWindow.xaml
    /// </summary>
    public partial class RegistratorWindow : Window
    {
        public RegistratorWindow(IDbCrud dbCrud, IComboService comboService, IDoctorService doctorService, IPatientService patientService, IReportService reportService, IVisitService visitService, ISheduleService sheduleService, IFileService fileService)
        {
            InitializeComponent();
            
            DataContext = new RegistratorViewModel(this, dbCrud, comboService, doctorService, patientService, reportService, visitService, sheduleService, fileService);
        }

        private void CardGrid_LayoutUpdated(object sender, EventArgs e)
        {

        }
    }
}
