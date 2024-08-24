using Microsoft.EntityFrameworkCore;
using RakicDental.Interfaces;
using RakicDental.Models;
using System.Collections.Generic;
using System.Linq;

namespace RakicDental.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Patient patient)
        {
            _context.Add(patient);
            _context.SaveChanges();
        }

        public void Delete(Patient patient)
        {
           _context.Remove(patient);
            _context.SaveChanges();
        }

        public List<Patient> GetAll()
        {
           return _context.Patients.OrderBy(x => x.Name).ToList();
        }

        public List<Patient> GetAllTreatments()
        {
            return _context.Patients.Include(x => x.Treatments).OrderBy(x => x.Name).ToList();
        }

        public List<Patient> GetByName(string name)
        {
           var lowerCaseName = name.ToLower();

           return _context.Patients
                .Include(x => x.Treatments)
                .Where(x => x.Name.ToLower().Contains(lowerCaseName))
                .OrderBy(x => x.Name).ToList();
        }

        public Patient GetOne(int id)
        {
            return _context.Patients.Include(x => x.Treatments).ThenInclude(x => x.Dentist).FirstOrDefault(x => x.Id == id);
        }

        public void Update(Patient patient)
        {
           _context.Entry(patient).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}

