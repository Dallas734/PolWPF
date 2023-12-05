namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Doctor")]
    public partial class Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor()
        {
            Certificate = new HashSet<Certificate>();
            Shedule = new HashSet<Shedule>();
            Visit = new HashSet<Visit>();
        }

        public int Id { get; set; }

        public int Specialization_id { get; set; }

        [Required]
        [StringLength(256)]
        public string LastName { get; set; }

        [Required]
        [StringLength(256)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(256)]
        public string Surname { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public int Status_id { get; set; }

        public int? Area_id { get; set; }

        public int Category_id { get; set; }

        public int? Gender_id { get; set; }

        public int? User_id { get; set; }

        public virtual Area Area { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Certificate> Certificate { get; set; }

        public virtual Gender Gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shedule> Shedule { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visit> Visit { get; set; }

        public virtual Specialization Specialization { get; set; }

        public virtual Status Status { get; set; }
    }
}
