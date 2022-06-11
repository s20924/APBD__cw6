using cw6.Models;
using cw6.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw6.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _mainDbContext;
        public DbService(MainDbContext dbContext)
        {
            _mainDbContext = dbContext;
        }

        public bool AddDoctor(Doctor doctor)
        {
            _mainDbContext.Doctors.Add(new Doctor ( doctor.FirstName, doctor.LastName, doctor.Email));
            _mainDbContext.SaveChanges();

            return true;
        }

        public bool DeleteDoctor(int idDoctor)
        {
            if(_mainDbContext.Doctors.Any(e => e.IdDoctor == idDoctor))
            {
                _mainDbContext.Remove(_mainDbContext.Doctors.Single(e => e.IdDoctor == idDoctor));
                _mainDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditDoctor(int idDoctor, Doctor doctor)
        {
            var result = _mainDbContext.Doctors.SingleOrDefault(d => d.IdDoctor == idDoctor);
            if (result != null)
            {
                result.FirstName = doctor.FirstName;
                result.LastName = doctor.LastName;
                result.Email = doctor.Email;
                _mainDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<SomeSortOfDoctor>> GetDoctors()
        {
            return await _mainDbContext.Doctors
                .Select(e => new SomeSortOfDoctor
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email
                }).ToListAsync();
        }

        public async Task<IEnumerable<SomeSortOfAll>> GetPrescription(int idPrescription)
        {
            return await _mainDbContext.Prescriptions
                .Where(e => e.IdPrescription == idPrescription)
                .Include(e => e.Doctor)
                .Include(e => e.Patient)
                .Include(e => e.Prescription_Medicaments)
                .Select(e => new SomeSortOfAll
                {
                    Date = e.Date,
                    DueDate = e.DueDate,
                    Doctor = e.Doctor,
                    Patient = e.Patient,
                    Medicaments = e.Prescription_Medicaments.Select(p => p.Medicament.Name)

                })
                .ToListAsync();
        }
    }
}
