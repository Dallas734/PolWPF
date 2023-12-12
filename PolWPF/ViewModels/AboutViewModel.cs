using PolWPF.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using System.Windows.Controls;
using BLL.Models;

namespace PolWPF.ViewModels
{
    public class AboutViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        TextBlock txt;
        AboutWindow aboutWindow;

        public AboutViewModel(AboutWindow window)
        {
            aboutWindow = window;
            txt = window.FindName("TextBlock") as TextBlock;
        }

        private RelayCommand aboutItemSelected;
        public RelayCommand AboutItemSelected
        {
            get
            {
                return aboutItemSelected ??
                    (aboutItemSelected = new RelayCommand(obj =>
                    {
                        txt.Text = "Программа предназначена для работы в ролях регистратора и врача. Позволяет регистратору работать с базой данных персонала больницы, записывать пациентов, составлять отчеты и тд. Врач с помощью данной системы может работать с пациентами.";

                    }));
            }
        }

        /*private void AboutItemSelected(object sender, RoutedEventArgs e)
        {
            txt.Text = "Программа предназначена для работы в ролях регистратора и врача. Позволяет регистратору работать с базой данных персонала больницы, записывать пациентов, составлять отчеты и тд. Врач с помощью данной системы может работать с пациентами.";
        }*/

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
