using BLL.Interfaces;
using BLL.Models;
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
    public class AddAddressViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        IDbCrud context;
        IComboService comboService;

        public ObservableCollection<AreaDTO> allAreas { get; set; }

        private string selectedName;
        public string SelectedName
        {
            get { return selectedName; }
            set
            {
                selectedName = value;
                OnPropertyChanged("SelectedName");
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

        public AddAddressViewModel(IDbCrud context, IComboService comboService)
        {
            this.context = context;
            this.comboService = comboService;

            allAreas = new ObservableCollection<AreaDTO>();

            comboService.FillObsCollection(allAreas, context.areaDTOs);
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
                            AddressDTO address = new AddressDTO();
                            address.Name = selectedName;
                            address.Area_id = selectedArea.Id;

                            context.AddAddress(address);
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
    }
}
