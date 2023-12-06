using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace PolWPF.ViewModels
{
    public class AddDoctorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        IDbCrud context;
        IComboService comboService;

        public ObservableCollection<SpecializationDTO> allSpecializations { get; set; }
        public ObservableCollection<CategoryDTO> allCategories { get; set; }
        public ObservableCollection<StatusDTO> allStatus { get; set; }
        public ObservableCollection<AreaDTO> allAreas { get; set; }
        public ObservableCollection<GenderDTO> allGenders { get; set; }

        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });

        private SpecializationDTO selectedSpecialization;
        public SpecializationDTO SelectedSpecialization
        {
            get { return selectedSpecialization; }
            set
            {
                selectedSpecialization = value;
                OnPropertyChanged("SelectedSpecialization");
            }
        }

        private string selectedLastName;
        public string SelectedLastName
        {
            get { return selectedLastName; }
            set
            {
                selectedLastName = value;
                OnPropertyChanged("SelectedLastName");
            }
        }

        private string selectedFirstName;
        public string SelectedFirstName
        {
            get { return selectedFirstName; }
            set
            {
                selectedFirstName = value;
                OnPropertyChanged("SelectedFirstName");
            }
        }

        private string selectedSurname;
        public string SelectedSurname
        {
            get { return selectedSurname; }
            set
            {
                selectedSurname = value;
                OnPropertyChanged("SelectedSurname");
            }
        }

        private DateTime selectedDate = DateTime.Now.Date;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                OnPropertyChanged("SelectedDate");
            }
        }

        private CategoryDTO selectedCategory;
        public CategoryDTO SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        private StatusDTO selectedStatus;
        public StatusDTO SelectedStatus
        {
            get { return selectedStatus; }
            set
            {
                selectedStatus = value;
                OnPropertyChanged("SelectedStatus");
            }
        }

        private AreaDTO selectedArea;
        public AreaDTO SelectedArea
        {
            get { return selectedArea; }
            set
            {
                selectedArea = value;
                OnPropertyChanged("SelectedArea");
            }
        }

        private GenderDTO selectedGender;
        public GenderDTO SelectedGender
        {
            get { return selectedGender; }
            set
            {
                selectedGender = value;
                OnPropertyChanged("SelectedGender");
            }
        }

        public AddDoctorViewModel(IDbCrud context, IComboService comboService)
        {
            this.context = context;
            allSpecializations = new ObservableCollection<SpecializationDTO>();
            allCategories = new ObservableCollection<CategoryDTO>();
            allStatus = new ObservableCollection<StatusDTO>();
            allAreas = new ObservableCollection<AreaDTO>();
            allGenders = new ObservableCollection<GenderDTO>();

            comboService.FillObsCollection<SpecializationDTO>(allSpecializations, context.specializationDTOs);
            comboService.FillObsCollection<CategoryDTO>(allCategories, context.categoryDTOs);
            comboService.FillObsCollection<StatusDTO>(allStatus, context.statusDTOs);
            comboService.FillObsCollection<AreaDTO>(allAreas, context.areaDTOs);
            comboService.FillObsCollection<GenderDTO>(allGenders, context.genderDTOs);
        }

        private RelayCommand submitCommand;
        public RelayCommand SubmitCommand
        {
            get
            {
                return submitCommand ??
                    (submitCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            DoctorDTO doctor = new DoctorDTO();
                            doctor.Specialization_id = SelectedSpecialization.Id;
                            doctor.LastName = SelectedLastName;
                            doctor.FirstName = SelectedFirstName;
                            doctor.Surname = SelectedSurname;
                            doctor.Gender_id = SelectedGender.Id;
                            doctor.DateOfBirth = SelectedDate;
                            doctor.Category_id = selectedCategory.Id;
                            doctor.Status_id = selectedStatus.Id;
                            doctor.Area_id = selectedArea.Id;

                            context.AddDoctor(doctor);
                            context.Save();

                            notifier.ShowSuccess("Добавление успешно");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        
                    }));
            }
        }
    }
}
