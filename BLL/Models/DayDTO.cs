using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class DayDTO
    {
        public DayDTO()
        {
        }
        public DayDTO(Day d)
        {
            Id = d.Id;
            Name = d.Name;
        }
        public short Id { get; set; }

        public string Name { get; set; }

    }
}
