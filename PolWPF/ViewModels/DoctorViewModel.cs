using BLL.Interfaces;
using BLL.Models;
using BLL.Models.ReportModels;
using DAL.Entities;
using LiveCharts.Defaults;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LiveCharts.Wpf;

namespace PolWPF.ViewModels
{
    public class DoctorViewModel : INotifyPropertyChanged
    {
        private int doctor_id = 1;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        IDbCrud context;
        IComboService comboService;
        IPatientService patientService;
        IReportService reportService;
        IVisitService visitService;
        ISheduleService sheduleService;
        IDoctorService doctorService;
        IFileService fileService;

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
                if (selectedTalon != null && selectedTalon.Visit != null)
                    selectedTalon.Patient = context.patientDTOs.Where(i => i.Id == selectedTalon.Visit.Patient_id).FirstOrDefault();
                OnPropertyChanged("SelectedTalon");
            }
        }

        private DiagnosisDTO selectedDiagnosisVisit;
        public DiagnosisDTO SelectedDiagnosisVisit
        {
            get => selectedDiagnosisVisit;
            set
            {
                selectedDiagnosisVisit = value;
                OnPropertyChanged("SelectedDiagnosisVisit");
            }
        }

        private ProcedureDTO selectedProcedure;
        public ProcedureDTO SelectedProcedure
        {
            get => selectedProcedure;
            set
            {
                selectedProcedure = value;
                OnPropertyChanged("SelectedProcedure");
            }
        }

        private string selectedRecipe;
        public string SelectedRecipe
        {
            get => selectedRecipe;
            set
            {
                selectedRecipe = value;
                OnPropertyChanged("SelectedRecipe");
            }
        }

        private DiagnosisDTO selectedDiagnosis;
        public DiagnosisDTO SelectedDiagnosis
        {
            get => selectedDiagnosis;
            set
            {
                selectedDiagnosis = value;
                OnPropertyChanged("SelectedDiagnosis");
            }
        }

        private string newDiagnosisName;
        public string NewDiagnosisName
        {
            get => newDiagnosisName;
            set
            {
                newDiagnosisName = value;
                OnPropertyChanged("NewDiagnosisName");
            }
        }

        public ObservableCollection<PatientDTO> AllPatients { get; set; }
        public ObservableCollection<DoctorDTO> AllDoctors { get; set; }
        public ObservableCollection<VisitDTO> PatientCard { get; set; }
        public ObservableCollection<DiagnosisDTO> AllDiagnosis { get; set; }
        public ObservableCollection<ProcedureDTO> AllProcedures { get; set; }

        public ObservableCollection<Talon> Talons { get; set; }

        public SeriesCollection Series { get; set; }

        public DoctorViewModel(IDbCrud context, IComboService comboService, IPatientService patientService, IReportService reportService, IVisitService visitService, ISheduleService sheduleService, IFileService fileService)
        {
            this.context = context;
            this.comboService = comboService;
            this.patientService = patientService;
            this.reportService = reportService;
            this.visitService = visitService;
            this.sheduleService = sheduleService;
            this.fileService = fileService;

            AllPatients = new ObservableCollection<PatientDTO>();
            PatientCard = new ObservableCollection<VisitDTO>();
            AllDoctors = new ObservableCollection<DoctorDTO>();
            AllDiagnosis = new ObservableCollection<DiagnosisDTO>();
            AllProcedures = new ObservableCollection<ProcedureDTO>();
            Talons = new ObservableCollection<Talon>();
            Series = new SeriesCollection();

            comboService.FillObsCollection(AllPatients, context.patientDTOs);
            comboService.FillObsCollection(AllDoctors, context.doctorDTOs);
            comboService.FillObsCollection(AllDiagnosis, context.diagnosisDTOs);
            comboService.FillObsCollection(AllProcedures, context.procedureDTOs);
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

        private RelayCommand getTalonsCommand;
        public RelayCommand GetTalonsCommand
        {
            get
            {
                return getTalonsCommand ??
                    (getTalonsCommand = new RelayCommand(obj =>
                    {
                        comboService.FillObsCollection<Talon>(Talons, visitService.GetTalons(context.doctorDTOs.Where(i => i.Id == doctor_id).FirstOrDefault(), SelectedDate));
                    },
                    (obj) => (selectedDate != null)));
            }
        }

        private RelayCommand completeVisitCommand;

        public RelayCommand CompleteVisitCommand
        {
            get
            {
                return completeVisitCommand ??
                    (completeVisitCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            Talon talon = obj as Talon;
                            VisitDTO visit = talon.Visit;
                            visit.Diagnosis_id = selectedDiagnosisVisit.Id;
                            visit.Procedure_id = selectedProcedure.Id;
                            visit.Recipe = selectedRecipe;
                            visit.VisitStatus_id = 2;

                            context.UpdateVisit(visit);
                            context.Save();
                            comboService.FillObsCollection<Talon>(Talons, visitService.GetTalons(context.doctorDTOs.Where(i => i.Id == doctor_id).FirstOrDefault(), SelectedDate));

                            MessageBox.Show("Запись успешно завершена!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    },
                    (obj) => selectedTalon != null && selectedProcedure != null && selectedDiagnosisVisit != null));
            }
        }

        private RelayCommand addDiagnosisCommand;
        public RelayCommand AddDiagnosisCommand
        {
            get
            {
                return addDiagnosisCommand ??
                    (addDiagnosisCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            DiagnosisDTO diagnosis = new DiagnosisDTO();
                            diagnosis.Name = newDiagnosisName;

                            context.AddDiagnosis(diagnosis);
                            context.Save();

                            MessageBox.Show("Успешно!");

                            comboService.FillObsCollection(AllDiagnosis, context.diagnosisDTOs);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    },
                    (obj) => newDiagnosisName != null));
            }
        }

        private RelayCommand deleteDiagnosisCommand;
        public RelayCommand DeleteDiagnosisCommand
        {
            get
            {
                return deleteDiagnosisCommand ??
                    (deleteDiagnosisCommand = new RelayCommand(obj =>
                    {
                        DiagnosisDTO diagnosis = obj as DiagnosisDTO;
                        context.DeleteDiagnosis(diagnosis);
                        context.Save();
                        comboService.FillObsCollection(AllDiagnosis, context.diagnosisDTOs);
                    },
                    (obj) => selectedDiagnosis != null));
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
                        Series.Clear();

                        List<ReportModel> reportList = reportService.MakeDiagnosisReport(doctor_id);
                        foreach (ReportModel report in reportList)
                        {
                            Series.Add(new PieSeries()
                            {
                                Title = report.Name,
                                DataLabels = true,
                                Values = new ChartValues<ObservableValue>() { new ObservableValue(report.Workload) }
                            });
                        }
                    }));
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
                        string header = "Отчет поставленных диагнозов у врача: " + context.doctorDTOs.Where(i => i.Id == doctor_id).FirstOrDefault().FullName;
                        fileService.Save("DiagnosisWorkloadReport.pdf", reportService.MakeDiagnosisReport(doctor_id), header);
                    }));
            }
        }
    }
}
