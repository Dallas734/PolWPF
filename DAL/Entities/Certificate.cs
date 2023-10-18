namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Certificate")]
    public partial class Certificate
    {
        public short Id { get; set; }

        public short Doctor_id { get; set; }

        [Required]
        [StringLength(13)]
        public string RegNum { get; set; }

        [Column(TypeName = "date")]
        public DateTime Issue { get; set; }

        [Column(TypeName = "date")]
        public DateTime Expiration { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
