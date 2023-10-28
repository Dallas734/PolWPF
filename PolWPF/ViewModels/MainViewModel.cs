using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PolWPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        IDbCrud context;
        IComboService comboService;
        IDoctorService doctorService;
        IPatientService patientService;
        IReportService reportService;
        IVisitService visitService;
        ISheduleService sheduleService;

        private MainWindow mainWindow;
        private RegistratorWindow _registratorWindow;
        private DoctorWindow _doctorWindow;

        private RelayCommand registratorAutCommand;
        public RelayCommand RegistratorAutCommand
        {
            get
            {
                return registratorAutCommand ??
                  (registratorAutCommand = new RelayCommand(obj =>
                  {
                      ToRegistratorPage(obj);
                  }));
            }
        }

        private RelayCommand doctorAutCommand;
        public RelayCommand DoctorAutCommand
        {
            get
            {
                return doctorAutCommand ??
                  (doctorAutCommand = new RelayCommand(obj =>
                  {
                      ToDoctorPage(obj);
                  }));
            }
        }

        public MainViewModel(MainWindow mainWindow, IDbCrud context, IComboService comboService, IDoctorService doctorService, IPatientService patientService, IReportService reportService, IVisitService visitService, ISheduleService sheduleService)
        {
            this.mainWindow = mainWindow;
            this.context = context;
            this.comboService = comboService;
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.reportService = reportService;
            this.visitService = visitService;
            this.sheduleService = sheduleService;
        }

        private void ToRegistratorPage(object obj)
        {
            _registratorWindow = new RegistratorWindow(context, comboService, doctorService, patientService, reportService, visitService, sheduleService);
            _registratorWindow.Show();
            mainWindow.Close(); 
        }

        private void ToDoctorPage(object obj)
        {
            _doctorWindow = new DoctorWindow(context, comboService, patientService, reportService, visitService, sheduleService);
            _doctorWindow.Show();
            mainWindow.Close();
        }
    }
}
