using Microsoft.EntityFrameworkCore;
using RakicDental.Interfaces;
using RakicDental.Models;
using System.Collections.Generic;
using System.Linq;

namespace RakicDental.Repository
{
    public class TreatmentRepository : ITreatmentsRepository
    {
        private readonly AppDbContext _context;
        public TreatmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
            _context.SaveChanges();
        }

        public void Delete(Treatment treatment)
        {
           _context.Treatments.Remove(treatment);
           _context.SaveChanges();
        }

        public List<Treatment> GetAll()
        {
            return _context.Treatments.Include(x => x.Patient).Include(x => x.Dentist).OrderByDescending(x => x.Date).ToList();
        }

        public Treatment GetOne(int id)
        {
           return _context.Treatments.Include(x => x.Patient).Include(x => x.Dentist).FirstOrDefault(x => x.Id == id);
        }

        public void Update(Treatment treatment)
        {
           _context.Entry(treatment).State = EntityState.Modified;

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
