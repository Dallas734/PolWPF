using BLL.Interfaces;
using BLL.Services;
using PolWPF.ViewModels;
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

namespace PolWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        TextBlock txt;
        public AboutWindow()
        {
            InitializeComponent();
            txt = FindName("TextBlock") as TextBlock;
            //DataContext = new AboutWindowViewModel();
        }

        private void AboutItemSelected(object sender, RoutedEventArgs e)
        {
            txt.Text = "Программа предназначена для работы в ролях регистратора и врача. Позволяет регистратору работать с базой данных персонала больницы, записывать пациентов, составлять отчеты и тд. Врач с помощью данной системы может работать с пациентами.";
        }

        private void PatientInfoItemSelected(object sender, RoutedEventArgs e)
        {
            txt.Text = "Сведения о пациентах больницы. Можно добавлять пациента, удалять и редактировать информацию о нем.";
        }

        private void AddVisitItemSelected(object sender, RoutedEventArgs e)
        {
            txt.Text = "Вкладка отвечает за запись пациента ко врачу.";
        }

        private void PatientVisitsItemSelected(object sender, RoutedEventArgs e)
        {
            txt.Text = "Позволяет просма тривать записи конкретного пациента и удалять их";
        }

        private void PatientCardItemSelected(object sender, RoutedEventArgs e)
        {
            txt.Text = "Карта пациента";
        }

        private void DoctorInfoItemSelected(object sender, RoutedEventArgs e)
        {
            txt.Text = "Сведения о врачах больницы. Можно добавлять врача, удалять и редактировать информацию о нем.";
        }

        private void ScheduleItemSelected(object sender, RoutedEventArgs e)
        {
            txt.Text = "Расписание врача с возмождностью его редактирования";
        }

        private void AreaReportItemSelected(object sender, RoutedEventArgs e)
        {
            txt.Text = "Позволяет составить отчет о загруженности враченй на определенном участке";
        }

        private void CardItemSelected(object sender, RoutedEventArgs e)
        {
            txt.Text = "Позволяет просмотреть карту пациента";
        }

        private void DoctorVisitItemSelected(object sender, RoutedEventArgs e)
        {
            txt.Text = "Позволяет просмотреть ваши записи на определенный день";
        }

        private void DiagnosisItemSelected(object sender, RoutedEventArgs e)
        {
            txt.Text = "Позволяет удалить или добавить диагнозы в систему";
        }

        private void DiagnosisReportItemSelected(object sender, RoutedEventArgs e)
        {
            txt.Text = "Позволяет составить отчет о поставленных диагнозах";
        }
    }
}
