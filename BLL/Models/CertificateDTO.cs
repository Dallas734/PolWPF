using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CertificateDTO
    {
        public CertificateDTO() { }

        public CertificateDTO(Certificate c)
        {
            Id = c.Id;
            Doctor_id = c.Doctor_id;
            RegNum = c.RegNum;
            Issue = c.Issue;
            Expiration = c.Expiration;
        }
        public int Id { get; set; }

        public int Doctor_id { get; set; }

        public string RegNum { get; set; }

        public DateTime Issue { get; set; }

        public DateTime Expiration { get; set; }

    }
}
