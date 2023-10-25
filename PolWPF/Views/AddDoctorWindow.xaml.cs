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

namespace PolWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для AddDoctorWindow.xaml
    /// </summary>
    public partial class AddDoctorWindow : Window
    {
        public AddDoctorWindow(IDbCrud dbCrud, IComboService comboService)
        {
            InitializeComponent();

            DataContext = new AddDoctorViewModel(dbCrud, comboService);
        }
    }
}
