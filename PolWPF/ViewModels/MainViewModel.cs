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

        private MainWindow mainWindow;
        private RegistratorWindow _registratorWindow;

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

        public MainViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        private void ToRegistratorPage(object obj)
        {
            _registratorWindow = new RegistratorWindow();
            _registratorWindow.Show();
            mainWindow.Close(); 
        }
    }
}
