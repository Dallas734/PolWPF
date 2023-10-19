using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class StatusDTO
    {
        public StatusDTO()
        {

        }

        public StatusDTO(Status s)
        {
            Id = s.Id;
            Name = s.Name;
        }

        public short Id { get; set; }

        public string Name { get; set; }

    }
}
