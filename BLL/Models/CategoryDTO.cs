using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class CategoryDTO
    {
        public CategoryDTO()
        {

        }

        public CategoryDTO(Category c)
        {
            Id = c.Id;
            Name = c.Name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

    }
}
