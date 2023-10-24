using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL
{
    public class DbDataOperations : IDbCrud
    {
        private IDbRepository dbRepos;

        public DbDataOperations(IDbRepository dbRepositorySQL)
        {
            dbRepos = dbRepositorySQL;
        }

        public List<AddressDTO> addressDTOs 
        { 
            get 
            {
                return dbRepos.Addresses.GetAll().Select(i => new AddressDTO(i)).ToList();
            } 
        }

        public void AddAddress(AddressDTO addressDTO)
        {
            dbRepos.Addresses.Create(new Address()
            {
                Id = addressDTO.Id,
                Area_id = addressDTO.Area_id,
                Name = addressDTO.Name
            });
        }

        public List<AreaDTO> areaDTOs 
        {
            get
            {
                return dbRepos.Areas.GetAll().Select(i => new AreaDTO(i)).ToList();
            }
        }
        public void AddArea(AreaDTO areaDTO)
        {
            dbRepos.Areas.Create(new Area()
            {
                Id = areaDTO.Id,
                Type = areaDTO.Type
            });
        }

        public List<CategoryDTO> categoryDTOs 
        { 
            get
            {
                return dbRepos.Categories.GetAll().Select(i => new CategoryDTO(i)).ToList();
            }
        }

        public List<CertificateDTO> certificateDTOs 
        {
            get
            {
                return dbRepos.Certificates.GetAll().Select(i => new CertificateDTO(i)).ToList();
            }
        }
        public void AddCertificate(CertificateDTO certificateDTO)
        {
            dbRepos.Certificates.Create(new Certificate()
            {
                Id = certificateDTO.Id,
                Doctor_id = certificateDTO.Doctor_id,
                RegNum = certificateDTO.RegNum,
                Issue = certificateDTO.Issue,
                Expiration = certificateDTO.Expiration
            });
        }

        public List<DayDTO> dayDTOs { 
            get
            {
                return dbRepos.Days.GetAll().Select(i => new DayDTO(i)).ToList();
            }
        }

        public List<DiagnosisDTO> diagnosisDTOs
        { 
            get
            {
                return dbRepos.Diagnosises.GetAll().Select(i => new DiagnosisDTO(i)).ToList();
            }
        }
        public void AddDiagnosis(DiagnosisDTO diagnosisDTO)
        {
            dbRepos.Diagnosises.Create(new Diagnosis()
            {
                Id= diagnosisDTO.Id,
                Name = diagnosisDTO.Name,
            });
        }

        public List<DoctorDTO> doctorDTOs 
        {
            get
            {
                return dbRepos.Doctors.GetAll().Select(i => new DoctorDTO(i)).ToList();
            }
        }
        public void AddDoctor(DoctorDTO doctorDTO)
        {
            dbRepos.Doctors.Create(new Doctor()
            {
                Id = doctorDTO.Id,
                Specialization_id= doctorDTO.Specialization_id,
                LastName = doctorDTO.LastName,
                FirstName = doctorDTO.FirstName,
                Surname = doctorDTO.Surname,
                DateOfBirth = doctorDTO.DateOfBirth,
                Status_id = doctorDTO.Status_id,
                Area_id = doctorDTO.Area_id,
                Category_id = doctorDTO.Category_id,
            });
        }

        public List<PatientDTO> patientDTOs 
        { 
            get
            {
                return dbRepos.Patients.GetAll().Select(i => new PatientDTO(i)).ToList();
            }
        }
        public void AddPatient(PatientDTO patientDTO)
        {
            dbRepos.Patients.Create(new Patient()
            {
                Id = patientDTO.Id,
                LastName = patientDTO.LastName,
                FirstName = patientDTO.FirstName,
                Surname = patientDTO.Surname,
                Gender = patientDTO.Gender,
                DateOfBirth = patientDTO.DateOfBirth,
                Address_id = patientDTO.Address_id,
                Polis = patientDTO.Polis,
                WorkPlace = patientDTO.WorkPlace,
            });
        }

        public List<ProcedureDTO> procedureDTOs 
        { 
            get
            {
                return dbRepos.Procedures.GetAll().Select(i => new ProcedureDTO(i)).ToList();
            }
        }
        public void AddProcedure(ProcedureDTO procedureDTO)
        {
            dbRepos.Procedures.Create(new Procedure()
            {
                Id = procedureDTO.Id,
                Name = procedureDTO.Name,
            });
        }

        public List<SpecializationDTO> specializationDTOs { 
            get
            {
                return dbRepos.Specializations.GetAll().Select(i => new SpecializationDTO(i)).ToList();
            }
        }
        public void AddSpecialization(SpecializationDTO specializationDTO)
        {
            dbRepos.Specializations.Create(new Specialization()
            {
                Id = specializationDTO.Id,
                Name = specializationDTO.Name,
            });
        }

        public List<StatusDTO> statusDTOs 
        { 
            get
            {
                return dbRepos.Statuses.GetAll().Select(i => new StatusDTO(i)).ToList();
            }
        }
        public void AddStatus(StatusDTO statusDTO)
        {
            dbRepos.Statuses.Create(new Status()
            {
                Id = statusDTO.Id,
                Name = statusDTO.Name,
            });
        }

        public List<VisitDTO> visitDTOs 
        {
            get
            {
                return dbRepos.Visits.GetAll().Select(i => new VisitDTO(i)).ToList();
            }
        }

        public List<VisitStatusDTO> visitStatusDTOs
        {
            get
            {
                return dbRepos.VisitStatuses.GetAll().Select(i => new VisitStatusDTO(i)).ToList();
            }
        }

        public void AddVisitStatus(VisitStatusDTO visitStatusDTO)
        {
            dbRepos.VisitStatuses.Create(new VisitStatus()
            {
                Id = visitStatusDTO.Id,
                Name = visitStatusDTO.Name,
            });
        }


        public bool Save()
        {
            if (dbRepos.Save() > 0) return true;
            return false;
        }
    }
}
