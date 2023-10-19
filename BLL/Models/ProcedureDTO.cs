using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ProcedureDTO
    {
        public ProcedureDTO()
        {

        }

        public ProcedureDTO(Procedure p)
        {
            Id = p.Id;
            Name = p.Name;
            Cost = p.Cost;
        }

        public short Id { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

    }
}
