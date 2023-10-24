namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visit")]
    public partial class Visit
    {
        public int Id { get; set; }

        public int Patient_id { get; set; }

        public int? Diagnosis_id { get; set; }

        [StringLength(256)]
        public string Recipe { get; set; }

        public int? Procedure_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateT { get; set; }

        public TimeSpan TimeT { get; set; }

        public int? Doctor_id { get; set; }

        public int? VisitStatus_id { get; set; }

        public virtual Diagnosis Diagnosis { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Procedure Procedure { get; set; }

        public virtual VisitStatus VisitStatus { get; set; }
    }
}
