namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shedule")]
    public partial class Shedule
    {
        public int Id { get; set; }

        public int Day_id { get; set; }

        public int Doctor_id { get; set; }

        public TimeSpan? BeginTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public virtual Day Day { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
