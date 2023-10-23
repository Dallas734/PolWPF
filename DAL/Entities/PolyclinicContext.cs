using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class PolyclinicContext : DbContext
    {
        public PolyclinicContext()
            : base("name=PolyclinicContext")
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Certificate> Certificate { get; set; }
        public virtual DbSet<Day> Day { get; set; }
        public virtual DbSet<Diagnosis> Diagnosis { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Procedure> Procedure { get; set; }
        public virtual DbSet<Shedule> Shedule { get; set; }
        public virtual DbSet<Specialization> Specialization { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }
        public virtual DbSet<VisitStatus> VisitStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasMany(e => e.Patient)
                .WithRequired(e => e.Address)
                .HasForeignKey(e => e.Address_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Area>()
                .HasMany(e => e.Address)
                .WithRequired(e => e.Area)
                .HasForeignKey(e => e.Area_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Area>()
                .HasMany(e => e.Doctor)
                .WithOptional(e => e.Area)
                .HasForeignKey(e => e.Area_id);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Doctor)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Category_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Day>()
                .HasMany(e => e.Shedule)
                .WithRequired(e => e.Day)
                .HasForeignKey(e => e.Day_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Diagnosis>()
                .HasMany(e => e.Visit)
                .WithOptional(e => e.Diagnosis)
                .HasForeignKey(e => e.Diagnosis_id);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Certificate)
                .WithRequired(e => e.Doctor)
                .HasForeignKey(e => e.Doctor_id);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Shedule)
                .WithRequired(e => e.Doctor)
                .HasForeignKey(e => e.Doctor_id);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Visit)
                .WithOptional(e => e.Doctor)
                .HasForeignKey(e => e.Doctor_id);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Visit)
                .WithRequired(e => e.Patient)
                .HasForeignKey(e => e.Patient_id);

            modelBuilder.Entity<Procedure>()
                .HasMany(e => e.Visit)
                .WithOptional(e => e.Procedure)
                .HasForeignKey(e => e.Procedure_id);

            modelBuilder.Entity<Shedule>()
                .Property(e => e.BeginTime)
                .HasPrecision(0);

            modelBuilder.Entity<Shedule>()
                .Property(e => e.EndTime)
                .HasPrecision(0);

            modelBuilder.Entity<Specialization>()
                .HasMany(e => e.Doctor)
                .WithRequired(e => e.Specialization)
                .HasForeignKey(e => e.Specialization_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Doctor)
                .WithRequired(e => e.Status)
                .HasForeignKey(e => e.Status_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VisitStatus>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VisitStatus>()
                .HasMany(e => e.Visit)
                .WithOptional(e => e.VisitStatus)
                .HasForeignKey(e => e.VisitStatus_id);
        }
    }
}
