using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Entities;

namespace BLL.Models
{
    public class AreaDTO
    {
        public AreaDTO()
        {
        }

        public AreaDTO(Area a, IDbCrud context)
        {
            Id = a.Id;
            Type = a.Type;
            Addresses = new ObservableCollection<AddressDTO>(context.addressDTOs.Where(i => i.Area_id == Id).ToList());
        }

        public int Id { get; set; }

        public string Type { get; set; }

        public ObservableCollection<AddressDTO> Addresses { get; set; }
    }
}
