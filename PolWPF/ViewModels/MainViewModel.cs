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
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;
using System.Windows.Controls;

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
        IFileService fileService;

        private MainWindow mainWindow;
        private RegistratorWindow _registratorWindow;
        private DoctorWindow _doctorWindow;

        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive),
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });

        private string login;
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private RelayCommand autCommand;
        public RelayCommand AutCommand
        {
            get
            {
                return autCommand ??
                  (autCommand = new RelayCommand(obj =>
                  {
                      Authentication(obj);
                  }));
            }
        }

        public MainViewModel(MainWindow mainWindow, IDbCrud context, IComboService comboService, IDoctorService doctorService, IPatientService patientService, IReportService reportService, IVisitService visitService, ISheduleService sheduleService, IFileService fileService)
        {
            this.mainWindow = mainWindow;
            this.context = context;
            this.comboService = comboService;
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.reportService = reportService;
            this.visitService = visitService;
            this.sheduleService = sheduleService;
            this.fileService = fileService;
        }

        private void ToRegistratorPage(object obj)
        {
            _registratorWindow = new RegistratorWindow(context, comboService, doctorService, patientService, reportService, visitService, sheduleService, fileService);
            _registratorWindow.Show();
            mainWindow.Close(); 
        }

        private void ToDoctorPage(object obj, int doctor_id)
        {
            _doctorWindow = new DoctorWindow(doctor_id, context, comboService, patientService, reportService, visitService, sheduleService, fileService);
            _doctorWindow.Show();
            mainWindow.Close();
        }

        private void Authentication(object obj)
        {
            PasswordBox box = obj as PasswordBox;
            password = box.Password;

            if (password == "" || login == "")
            {
                notifier.ShowError("Введите все данные");
                return;
            }

            var user = context.usersDTOs.Where(i => i.Login == login && i.Password == password).FirstOrDefault();
            if (user == null)
            {
                notifier.ShowError("Введен неправильный логин или пароль");
            }
            else
            {
                if (user.Role_id == 1)
                    ToRegistratorPage(obj);
                else if (user.Role_id == 2)
                {
                    int doctor_id = context.doctorDTOs.Where(i => i.User_id == user.Id).FirstOrDefault().Id;
                    ToDoctorPage(obj, doctor_id);
                }
            }
        }
    }
}
