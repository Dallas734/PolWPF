using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
    public class UserDTO
    {
        public UserDTO(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Password = user.Password;
            Role_id = user.Role_id;
        }
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int? Role_id { get; set; }
    }
}
