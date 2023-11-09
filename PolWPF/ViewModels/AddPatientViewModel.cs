using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using PolWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PolWPF.ViewModels
{
    public class AddPatientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private AddAddressWindow _addAddressWindow;

        IDbCrud context;
        IComboService comboService;

        public ObservableCollection<GenderDTO> allGenders { get; set; }

        private ObservableCollection<AddressDTO> allAddresses;
        public ObservableCollection<AddressDTO> AllAddresses
        {
            get { return allAddresses; }
            set
            {
                allAddresses = value;
                OnPropertyChanged("AllAddresses");
            }
        }

        public ObservableCollection<AreaDTO> allAreas { get; set; }

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

        private AreaDTO selectedArea;
        public AreaDTO SelectedArea
        {
            get { return selectedArea; }
            set
            {
                selectedArea = value;
                AllAddresses = new ObservableCollection<AddressDTO>(context.addressDTOs.Where(i => i.Area_id == selectedArea.Id).ToList());
                OnPropertyChanged("SelectedArea");
            }
        }

        private AddressDTO selectedAddress;
        public AddressDTO SelectedAddress
        {
            get { return selectedAddress; }
            set
            {
                selectedAddress = value;
                OnPropertyChanged("SelectedAddress");
            }
        }

        private string selectedPolis;
        public string SelectedPolis
        {
            get { return selectedPolis; }
            set
            {
                selectedPolis = value;
                OnPropertyChanged("SelectedPolis");
            }
        }

        private string selectedWorkPlace;
        public string SelectedWorkPlace
        {
            get { return selectedWorkPlace; }
            set
            {
                selectedWorkPlace = value;
                OnPropertyChanged("SelectedWorkPlace");
            }
        }

        public AddPatientViewModel(IDbCrud context, IComboService comboService)
        {
            this.context = context;
            this.comboService = comboService;
            //allAddresses = new ObservableCollection<AddressDTO>();
            allAreas = new ObservableCollection<AreaDTO>();
            allGenders = new ObservableCollection<GenderDTO>();

            //comboService.FillObsCollection<AddressDTO>(allAddresses, context.addressDTOs);
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
                            PatientDTO patient = new PatientDTO();
                            patient.LastName = SelectedLastName;
                            patient.FirstName = SelectedFirstName;
                            patient.Surname = SelectedSurname;
                            patient.Gender_id = selectedGender.Id;
                            patient.DateOfBirth = SelectedDate;
                            patient.Address_id = SelectedAddress.Id;
                            patient.Polis = selectedPolis;
                            patient.WorkPlace = selectedWorkPlace;

                            context.AddPatient(patient);
                            context.Save();

                            MessageBox.Show("Успешно!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }));
            }
        }

        private RelayCommand addAddressCommand;
        public RelayCommand AddAddressCommand
        {
            get
            {
                return addAddressCommand ??
                    (addAddressCommand = new RelayCommand(obj =>
                    {
                        _addAddressWindow = new AddAddressWindow(context, comboService);
                        _addAddressWindow.ShowDialog();
                        if (selectedArea != null)
                        {
                            AllAddresses = new ObservableCollection<AddressDTO>(context.addressDTOs.Where(i => i.Area_id == selectedArea.Id).ToList());
                        }
                    }));
            }
        }

    }
}
