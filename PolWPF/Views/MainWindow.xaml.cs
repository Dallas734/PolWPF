using BLL.Interfaces;
using PolWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Ninject;
using PolWPF.Util;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PolWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        IDbCrud dbCrud;
        IComboService comboService;
        IDoctorService doctorService;
        IPatientService patientService;
        IReportService reportService;
        IVisitService visitService;
        ISheduleService sheduleService;
        public MainWindow()
        {
            InitializeComponent();
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("PolyclinicContext"));

            dbCrud = kernel.Get<IDbCrud>();
            comboService = kernel.Get<IComboService>();
            doctorService = kernel.Get<IDoctorService>();
            patientService = kernel.Get<IPatientService>();
            reportService = kernel.Get<IReportService>();
            visitService = kernel.Get<IVisitService>();
            sheduleService = kernel.Get<ISheduleService>();

            DataContext = new MainViewModel(this, dbCrud, comboService, doctorService, patientService, reportService, visitService, sheduleService);
        }
    }

    public class MyConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
