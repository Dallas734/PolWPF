using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class AreaDTO
    {
        public AreaDTO()
        {
        }

        public AreaDTO(Area a)
        {
            Id = a.Id;
            Type = a.Type;
        }

        public short Id { get; set; }

        public string Type { get; set; }


    }
}
