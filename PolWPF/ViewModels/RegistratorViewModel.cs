using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;

namespace PolWPF.ViewModels
{
    public class RegistratorViewModel : INotifyPropertyChanged
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
        public short _Id = 0;

        public ObservableCollection<DoctorDTO> allDoctors { get; set; }
        public ObservableCollection<PatientDTO> allPatients { get; set; }
        public ObservableCollection<SpecializationDTO> allSpecializations { get; set; }
        public ObservableCollection<StatusDTO> allStatus { get; set; }
        public ObservableCollection<CategoryDTO> allCategories { get; set; }
        public ObservableCollection<AddressDTO> allAddresses { get; set; }

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

            comboService.FillObsCollection<DoctorDTO>(allDoctors, context.doctorDTOs);
            comboService.FillObsCollection(allPatients, context.patientDTOs);
            comboService.FillObsCollection<SpecializationDTO>(allSpecializations, context.specializationDTOs);
            comboService.FillObsCollection<StatusDTO>(allStatus, context.statusDTOs);
            comboService.FillObsCollection<CategoryDTO>(allCategories, context.categoryDTOs);
            comboService.FillObsCollection<AddressDTO>(allAddresses, context.addressDTOs);
        }

    }

}
