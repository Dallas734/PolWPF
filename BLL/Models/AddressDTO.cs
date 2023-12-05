using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class AddressDTO
    {
        public AddressDTO()
        {

        }

        public AddressDTO(Address a)
        {
            Id = a.Id;
            Area_id = (int)a.Area_id;
            Name = a.Name;
        }

        public int Id { get; set; }

        public int Area_id { get; set; }

        public string Name { get; set; }

    }
}
