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
using LiveCharts.Wpf;
using BLL.Models.ReportModels;
using LiveCharts;
using LiveCharts.Defaults;

namespace PolWPF.ViewModels
{
    public class RegistratorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private MainWindow _mainWindow;
        private RegistratorWindow _registratorWindow;
        private AddDoctorWindow _addDoctorWindow;
        private AddPatientWindow _addPatientWindow;

        IDbCrud context;
        IComboService comboService;
        IDoctorService doctorService;
        IPatientService patientService;
        IReportService reportService;
        IVisitService visitService;
        ISheduleService sheduleService;
        IFileService fileService;


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

        private DoctorDTO selectedSheduleDoctor;

        public DoctorDTO SelectedSheduleDoctor
        {
            get { return selectedSheduleDoctor; }
            set 
            { 
                selectedSheduleDoctor = value;
                OnPropertyChanged("SelectedSheduleDoctor");
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
                if(selectedTalon != null && selectedTalon.Visit != null)
                    selectedTalon.Patient = context.patientDTOs.Where(i => i.Id == selectedTalon.Visit.Patient_id).FirstOrDefault();
                OnPropertyChanged("SelectedTalon");
            }
        }

        private PatientDTO selectedVisitPatient;
        public PatientDTO SelectedVisitPatient
        {
            get
            {
                return selectedVisitPatient;
            }
            set
            {
                selectedVisitPatient = value;
                OnPropertyChanged("SelectedVisitPatient");
            }
        }

        private PatientDTO selectedCardPatient;
        public PatientDTO SelectedCardPatient
        {
            get
            {
                return selectedCardPatient;
            }
            set
            {
                selectedCardPatient = value;
                OnPropertyChanged("SelectedCardPatient");
            }
        }

        private DateTime selectedVisitDate = DateTime.Now.Date;
        public DateTime SelectedVisitDate
        {
            get { return selectedVisitDate; }
            set
            {
                selectedVisitDate = value;
                OnPropertyChanged("SelectedVisitDate");
            }
        }

        private VisitDTO selectedFutureVisit;
        public VisitDTO SelectedFutureVisit
        {
            get
            {
                return selectedFutureVisit;
            }
            set
            {
                selectedFutureVisit = value;
                OnPropertyChanged("SelectedFutureVisit");
            }
        }

        private SheduleDTO selectedSheduleItem;
        public SheduleDTO SelectedSheduleItem
        {
            get
            {
                return selectedSheduleItem;
            }
            set
            {
                selectedSheduleItem = value;
                OnPropertyChanged("SelectedSheduleItem");
            }
        }

        private AreaDTO selectedReportArea;

        public AreaDTO SelectedReportArea
        {
            get { return selectedReportArea; }
            set
            {
                selectedReportArea = value;
                OnPropertyChanged("SelectedReportArea");
            }
        }

        private DateTime beginReportDate = DateTime.Now.Date;
        public DateTime BeginReportDate
        {
            get { return beginReportDate; }
            set
            {
                beginReportDate = value;
                OnPropertyChanged("BeginReportDate");
            }
        }

        private DateTime endReportDate = DateTime.Now.Date;
        public DateTime EndReportDate
        {
            get { return endReportDate; }
            set
            {
                endReportDate = value;
                OnPropertyChanged("EndReportDate");
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

        public ObservableCollection<DiagnosisDTO> AllDiagnosis { get; set; }

        public ObservableCollection<ProcedureDTO> AllProcedures { get; set; }

        public ObservableCollection<VisitDTO> AllPatientVisit { get; set; }

        public ObservableCollection<VisitDTO> PatientCard { get; set; }

        public ObservableCollection<Talon> Talons { get; set; }

        public ObservableCollection<SheduleDTO> DoctorShedule { get; set; }

        public SeriesCollection Series { get; set; }

        public RegistratorViewModel(RegistratorWindow registratorWindow, IDbCrud context, IComboService comboService, IDoctorService doctorService, IPatientService patientService, IReportService reportService, IVisitService visitService, ISheduleService sheduleService, IFileService fileService)
        {
            this._registratorWindow = registratorWindow;
            this.context = context;
            this.comboService = comboService;
            this.doctorService = doctorService;
            this.patientService = patientService;
            this.reportService = reportService;
            this.visitService = visitService;
            this.sheduleService = sheduleService;
            this.fileService = fileService;

            AllNowDoctors = new ObservableCollection<DoctorDTO>();
            AllDoctors = new ObservableCollection<DoctorDTO>();
            AllPatients = new ObservableCollection<PatientDTO>();
            AllSpecializations = new ObservableCollection<SpecializationDTO>();
            AllStatus = new ObservableCollection<StatusDTO>();
            AllCategories = new ObservableCollection<CategoryDTO>();
            AllAddresses = new ObservableCollection<AddressDTO>();
            AllGenders = new ObservableCollection<GenderDTO>();
            AllAreas = new ObservableCollection<AreaDTO>();
            AllDiagnosis = new ObservableCollection<DiagnosisDTO>();
            AllProcedures = new ObservableCollection<ProcedureDTO>();
            Talons = new ObservableCollection<Talon>();
            AllPatientVisit = new ObservableCollection<VisitDTO>();
            PatientCard = new ObservableCollection<VisitDTO>();
            DoctorShedule = new ObservableCollection<SheduleDTO>();
            Series = new SeriesCollection();

            comboService.FillObsCollection<DoctorDTO>(AllDoctors, context.doctorDTOs);
            comboService.FillObsCollection<PatientDTO>(AllPatients, context.patientDTOs);
            comboService.FillObsCollection<SpecializationDTO>(AllSpecializations, context.specializationDTOs);
            comboService.FillObsCollection<StatusDTO>(AllStatus, context.statusDTOs);
            comboService.FillObsCollection<CategoryDTO>(AllCategories, context.categoryDTOs);
            comboService.FillObsCollection<AddressDTO>(AllAddresses, context.addressDTOs);
            comboService.FillObsCollection<GenderDTO>(AllGenders, context.genderDTOs);
            comboService.FillObsCollection<AreaDTO>(AllAreas, context.areaDTOs);
            comboService.FillObsCollection<DiagnosisDTO>(AllDiagnosis, context.diagnosisDTOs);
            comboService.FillObsCollection<ProcedureDTO>(AllProcedures, context.procedureDTOs);
        }

        private void ToMainWindow(object obj)
        {
            _mainWindow = new MainWindow();
            _mainWindow.Show();
            _registratorWindow.Close();
        }

        private RelayCommand toMainWindowCommand;
        public RelayCommand ToMainWindowCommand
        {
            get
            {
                return toMainWindowCommand ??
                  (toMainWindowCommand = new RelayCommand(obj =>
                  {
                      ToMainWindow(obj);
                  }));
            }
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
                        comboService.FillObsCollection<Talon>(Talons, visitService.GetTalons(SelectedDoctor, SelectedDate));
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
                        try
                        {
                            Talon talon = obj as Talon;
                            VisitDTO visit = new VisitDTO();
                            visit.Diagnosis_id = 9;
                            visit.Procedure_id = 4;
                            visit.Patient_id = selectedPatient.Id;
                            visit.Doctor_id = selectedDoctor.Id;
                            visit.DateT = selectedDate;
                            visit.TimeT = talon.Time;
                            visit.VisitStatus_id = 1;

                            context.AddVisit(visit);
                            context.Save();

                            MessageBox.Show("Успешно!");

                            comboService.FillObsCollection<Talon>(Talons, visitService.GetTalons(SelectedDoctor, SelectedDate));
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    },
                    (obj) => (selectedTalon != null && selectedTalon.Visit == null && selectedPatient != null)));
            }
        }

        private RelayCommand removeVisitCommand;
        public RelayCommand RemoveVisitCommand
        {
            get
            {
                return removeVisitCommand ??
                  (removeVisitCommand = new RelayCommand(obj =>
                  {
                      Talon talon = obj as Talon;
                      context.DeleteVisit(talon.Visit);
                      context.Save();
                      comboService.FillObsCollection<Talon>(Talons, visitService.GetTalons(SelectedDoctor, SelectedDate));
                  },
                 //условие, при котором будет доступна команда
                 (obj) => (selectedTalon != null && selectedTalon.Visit != null)));
            }
        }


        private RelayCommand showPatientVisits;
        public RelayCommand ShowPatientVisits
        {
            get
            {
                return showPatientVisits ??
                  (showPatientVisits = new RelayCommand(obj =>
                  {
                      comboService.FillObsCollection<VisitDTO>(AllPatientVisit, visitService.GetFutureVisitsOnPatientAndDate(selectedVisitPatient, selectedVisitDate));
                  },
                 //условие, при котором будет доступна команда
                 (obj) => (selectedVisitDate != null && selectedVisitPatient != null)));
            }
        }

        private RelayCommand deletePatientVisits;
        public RelayCommand DeletePatientVisits
        {
            get
            {
                return deletePatientVisits ??
                  (deletePatientVisits = new RelayCommand(obj =>
                  {
                      try
                      {
                          VisitDTO visit = obj as VisitDTO;
                          context.DeleteVisit(visit);
                          context.Save();
                          comboService.FillObsCollection<VisitDTO>(AllPatientVisit, visitService.GetFutureVisitsOnPatientAndDate(selectedVisitPatient, selectedVisitDate));
                          MessageBox.Show("Успешно");
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  },
                 //условие, при котором будет доступна команда
                 (obj) => (selectedFutureVisit != null)));
            }
        }

        private RelayCommand showPatientCard;
        public RelayCommand ShowPatientCard
        {
            get
            {
                return showPatientCard ??
                    (showPatientCard = new RelayCommand(obj =>
                    {
                        PatientDTO patient = obj as PatientDTO;
                        comboService.FillObsCollection(PatientCard, patientService.GetPatientCard(patient));
                    },
                    (obj) => (selectedCardPatient != null)));
            }
        }

        private RelayCommand getSheduleCommand;
        public RelayCommand GetSheduleCommand
        {
            get
            {
                return getSheduleCommand ??
                    (getSheduleCommand = new RelayCommand(obj =>
                    {
                        DoctorDTO doctor = obj as DoctorDTO;
                        comboService.FillObsCollection(DoctorShedule, sheduleService.GetSheduleOnDoctor(doctor));
                    },
                    (obj) => (selectedSheduleDoctor != null)));
            }
        }

        private RelayCommand saveSheduleCommand;
        public RelayCommand SaveSheduleCommand
        {
            get
            {
                return saveSheduleCommand ??
                    (saveSheduleCommand = new RelayCommand(obj =>
                    {
                        SheduleDTO shedule = obj as SheduleDTO;
                        context.UpdateShedule(shedule);
                        context.Save();
                        MessageBox.Show("Изменения сохранены!");
                    },
                    (obj) => (selectedSheduleItem != null)));
            }
        }

        private RelayCommand getReportCommand;
        public RelayCommand GetReportCommand
        {
            get
            {
                return getReportCommand ??
                    (getReportCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            AreaDTO area = obj as AreaDTO;
                            Series.Clear();

                            List<ReportModel> reportList = reportService.MakeWorkloadReport(area.Id, beginReportDate, endReportDate);
                            foreach (ReportModel report in reportList)
                            {
                                Series.Add(new PieSeries()
                                {
                                    Title = report.Name,
                                    DataLabels = true,
                                    Values = new ChartValues<ObservableValue>() { new ObservableValue(report.Workload) }
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    },
                    (obj) => (selectedReportArea != null && beginReportDate != null && endReportDate != null)));
            }
        }

        private RelayCommand saveFileCommand;
        public RelayCommand SaveFileCommand
        {
            get
            {
                return saveFileCommand ??
                    (saveFileCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            AreaDTO areaDTO = obj as AreaDTO;
                            string header = "Отчет загруженности на участке №" + areaDTO.Id + " c " + beginReportDate.ToString("dd/MM/yyyy") + " по " + endReportDate.ToString("dd/MM/yyyy");
                            fileService.Save("DoctorWorkloadReport.pdf", reportService.MakeWorkloadReport(areaDTO.Id, beginReportDate, endReportDate), header);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    },
                    (obj) => (selectedReportArea != null && beginReportDate != null && endReportDate != null)));
            }
        }
    }
}
