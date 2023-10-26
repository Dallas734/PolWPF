using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BLL.Interfaces;
using BLL.Models;
using PolWPF.Views;

namespace PolWPF.ViewModels
{
    public class RegistratorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private AddDoctorWindow _addDoctorWindow;
        private AddPatientWindow _addPatientWindow;

        IDbCrud context;
        IComboService comboService;
        IDoctorService doctorService;
        IPatientService patientService;
        IReportService reportService;
        IVisitService visitService;


        private PatientDTO selectedPatient;
        public PatientDTO SelectedPatient
        {
            get
            {
                return selectedPatient;
            }
            set
            {
                selectedPatient = value;
                OnPropertyChanged("SelectedPatient");
            }
        }

        private DoctorDTO selectedDoctor;
        public DoctorDTO SelectedDoctor
        {
            get { return selectedDoctor; }
            set
            {
                selectedDoctor = value;
                OnPropertyChanged("SelectedDoctor");
            }
        }

        private AreaDTO selectedArea;
        public AreaDTO SelectedArea
        {
            get { return selectedArea;}
            set
            {
                selectedArea = value;
                if (SelectedSpecialization != null)
                    AllNowDoctors = new ObservableCollection<DoctorDTO>(doctorService.GetDoctorsOnAreaAndSpecialization(SelectedArea.Id, SelectedSpecialization.Id));
                AllNowPatients = new ObservableCollection<PatientDTO>(patientService.GetPatientsOnArea(selectedArea.Id));
                OnPropertyChanged("SelectedArea");
            }
        }

        private SpecializationDTO selectedSpecialization;
        public SpecializationDTO SelectedSpecialization
        {
            get
            {
                return selectedSpecialization;
            }
            set
            {
                selectedSpecialization = value;
                if (SelectedArea != null)
                    AllNowDoctors = new ObservableCollection<DoctorDTO>(doctorService.GetDoctorsOnAreaAndSpecialization(SelectedArea.Id, SelectedSpecialization.Id));
                OnPropertyChanged("SelectedSpecialization");
            }
        }

        private ObservableCollection<DoctorDTO> allNowDoctors;
        public ObservableCollection<DoctorDTO> AllNowDoctors
        {
            get
            {
                return allNowDoctors;
            }
            set
            {
                allNowDoctors = value;
                OnPropertyChanged("AllNowDoctors");
            }
        }

        private ObservableCollection<PatientDTO> allNowPatients;
        public ObservableCollection<PatientDTO> AllNowPatients
        {
            get { return allNowPatients; }
            set
            {
                allNowPatients = value;
                OnPropertyChanged("AllNowPatients");
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

        public Talon selectedTalon;
        public Talon SelectedTalon
        {
            get { return selectedTalon; }
            set
            {
                selectedTalon = value;
                OnPropertyChanged("SelectedTalon");
            }
        }

        public ObservableCollection<DoctorDTO> AllDoctors { get; set; }
        public ObservableCollection<PatientDTO> AllPatients { get; set; }
        public ObservableCollection<SpecializationDTO> AllSpecializations { get; set; }
        public ObservableCollection<StatusDTO> AllStatus { get; set; }
        public ObservableCollection<CategoryDTO> AllCategories { get; set; }
        public ObservableCollection<AddressDTO> AllAddresses { get; set; }

        public ObservableCollection<GenderDTO> AllGenders { get; set; }

        public ObservableCollection<AreaDTO> AllAreas { get; set; }

        private ObservableCollection<Talon> talons;
        public ObservableCollection<Talon> Talons
        { 
            get
            {
                return talons;
            } 
            set
            {
                talons = value;
                OnPropertyChanged("Talons");
            }
        }

        public RegistratorViewModel(IDbCrud context, IComboService comboService, IDoctorService doctorService, IPatientService patientService, IReportService reportService, IVisitService visitService)
        {
            this.context = context;
            this.comboService = comboService;
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.reportService = reportService;
            this.visitService = visitService;

            AllNowDoctors = new ObservableCollection<DoctorDTO>();
            AllDoctors = new ObservableCollection<DoctorDTO>();
            AllPatients = new ObservableCollection<PatientDTO>();
            AllSpecializations = new ObservableCollection<SpecializationDTO>();
            AllStatus = new ObservableCollection<StatusDTO>();
            AllCategories = new ObservableCollection<CategoryDTO>();
            AllAddresses = new ObservableCollection<AddressDTO>();
            AllGenders = new ObservableCollection<GenderDTO>();
            AllAreas = new ObservableCollection<AreaDTO>();
            Talons = new ObservableCollection<Talon>();

            comboService.FillObsCollection<DoctorDTO>(AllDoctors, context.doctorDTOs);
            comboService.FillObsCollection<PatientDTO>(AllPatients, context.patientDTOs);
            comboService.FillObsCollection<SpecializationDTO>(AllSpecializations, context.specializationDTOs);
            comboService.FillObsCollection<StatusDTO>(AllStatus, context.statusDTOs);
            comboService.FillObsCollection<CategoryDTO>(AllCategories, context.categoryDTOs);
            comboService.FillObsCollection<AddressDTO>(AllAddresses, context.addressDTOs);
            comboService.FillObsCollection<GenderDTO>(AllGenders, context.genderDTOs);
            comboService.FillObsCollection<AreaDTO>(AllAreas, context.areaDTOs);
        }

        private RelayCommand removePatientCommand;
        public RelayCommand RemovePatientCommand
        {
            get
            {
                return removePatientCommand ??
                  (removePatientCommand = new RelayCommand(obj =>
                  {
                      PatientDTO patient = obj as PatientDTO;
                      if (patient != null)
                      {
                          AllPatients.Remove(patient);
                          context.DeletePatient(patient);
                          context.Save();
                      }
                  },
                 //условие, при котором будет доступна команда
                 (obj) => (AllPatients.Count > 0 && selectedPatient != null)));
            }
        }

        private RelayCommand removeDoctorCommand;
        public RelayCommand RemoveDoctorCommand
        {
            get
            {
                return removeDoctorCommand ??
                  (removeDoctorCommand = new RelayCommand(obj =>
                  {
                      DoctorDTO doctor = obj as DoctorDTO;
                      if (doctor != null)
                      {
                          AllDoctors.Remove(doctor);
                          context.DeleteDoctor(doctor);
                          context.Save();
                      }
                  },
                 //условие, при котором будет доступна команда
                 (obj) => (AllDoctors.Count > 0 && selectedDoctor != null)));
            }
        }

        private RelayCommand addDoctorCommand;
        public RelayCommand AddDoctorCommand
        {
            get
            {
                return addDoctorCommand ??
                 (addDoctorCommand = new RelayCommand(obj =>
                 {
                     _addDoctorWindow = new AddDoctorWindow(context, comboService);
                     _addDoctorWindow.ShowDialog();
                     comboService.FillObsCollection(AllDoctors, context.doctorDTOs);
                 }));

            }
        }

        private RelayCommand addPatientCommand;
        public RelayCommand AddPatientCommand
        {
            get
            {
                return addPatientCommand ??
                    (addPatientCommand = new RelayCommand(obj =>
                    {
                        _addPatientWindow = new AddPatientWindow(context, comboService);
                        _addPatientWindow.ShowDialog();
                        comboService.FillObsCollection(AllPatients, context.patientDTOs);
                    }));
            }
        }

        private RelayCommand saveDoctorCommand;
        public RelayCommand SaveDoctorCommand
        {
            get
            {
                return saveDoctorCommand ??
                    (saveDoctorCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            DoctorDTO doctor = obj as DoctorDTO;
                            if (doctor != null)
                            {
                                context.UpdateDoctor(doctor);
                                context.Save();
                                MessageBox.Show("Изменения сохранены!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    },
                    (obj) => (AllDoctors.Count > 0 && selectedDoctor != null)));
            }
        }

        private RelayCommand savePatientCommand;
        public RelayCommand SavePatientCommand
        {
            get
            {
                return savePatientCommand ??
                    (savePatientCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            PatientDTO patient = obj as PatientDTO;
                            if (patient != null)
                            {
                                context.UpdatePatient(patient);
                                context.Save();
                                MessageBox.Show("Изменения сохранены!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    },
                    (obj) => (AllPatients.Count > 0 && selectedPatient != null)));
            }

        }

        private RelayCommand getTalonsCommand;
        public RelayCommand GetTalonsCommand
        {
            get
            {
                return getTalonsCommand ??
                    (getTalonsCommand = new RelayCommand(obj =>
                    {
                        Talons = new ObservableCollection<Talon>(visitService.GetTalons(SelectedDoctor, SelectedDate));
                    },
                    (obj) => (selectedDoctor != null && selectedDate != null)));
            }
        }

        private RelayCommand addVisitCommand;
        public RelayCommand AddVisitCommand
        {
            get
            {
                return addVisitCommand ??
                    (addVisitCommand = new RelayCommand(obj =>
                    {
                        
                        
                    }));
            }
        }

    }
}
