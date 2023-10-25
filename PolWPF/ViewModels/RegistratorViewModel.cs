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

        public ObservableCollection<DoctorDTO> allDoctors { get; set; }
        public ObservableCollection<PatientDTO> allPatients { get; set; }
        public ObservableCollection<SpecializationDTO> allSpecializations { get; set; }
        public ObservableCollection<StatusDTO> allStatus { get; set; }
        public ObservableCollection<CategoryDTO> allCategories { get; set; }
        public ObservableCollection<AddressDTO> allAddresses { get; set; }

        public ObservableCollection<GenderDTO> allGenders { get; set; }

        public RegistratorViewModel(IDbCrud context, IComboService comboService, IDoctorService doctorService, IPatientService patientService, IReportService reportService, IVisitService visitService)
        {
            this.context = context;
            this.comboService = comboService;
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.reportService = reportService;
            this.visitService = visitService;

            allDoctors = new ObservableCollection<DoctorDTO>();
            allPatients = new ObservableCollection<PatientDTO>();
            allSpecializations = new ObservableCollection<SpecializationDTO>();
            allStatus = new ObservableCollection<StatusDTO>();
            allCategories = new ObservableCollection<CategoryDTO>();
            allAddresses = new ObservableCollection<AddressDTO>();
            allGenders = new ObservableCollection<GenderDTO>();

            comboService.FillObsCollection<DoctorDTO>(allDoctors, context.doctorDTOs);
            comboService.FillObsCollection<PatientDTO>(allPatients, context.patientDTOs);
            comboService.FillObsCollection<SpecializationDTO>(allSpecializations, context.specializationDTOs);
            comboService.FillObsCollection<StatusDTO>(allStatus, context.statusDTOs);
            comboService.FillObsCollection<CategoryDTO>(allCategories, context.categoryDTOs);
            comboService.FillObsCollection<AddressDTO>(allAddresses, context.addressDTOs);
            comboService.FillObsCollection<GenderDTO>(allGenders, context.genderDTOs);
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
                          allPatients.Remove(patient);
                          context.DeletePatient(patient);
                          context.Save();
                      }
                  },
                 //условие, при котором будет доступна команда
                 (obj) => (allPatients.Count > 0 && selectedPatient != null)));
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
                          allDoctors.Remove(doctor);
                          context.DeleteDoctor(doctor);
                          context.Save();
                      }
                  },
                 //условие, при котором будет доступна команда
                 (obj) => (allDoctors.Count > 0 && selectedDoctor != null)));
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
                     comboService.FillObsCollection(allDoctors, context.doctorDTOs);
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
                        comboService.FillObsCollection(allPatients, context.patientDTOs);
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
                    (obj) => (allDoctors.Count > 0 && selectedDoctor != null)));
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
                    (obj) => (allPatients.Count > 0 && selectedPatient != null)));
            }

        }

    }
}
