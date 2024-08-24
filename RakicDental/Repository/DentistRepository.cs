
using Microsoft.EntityFrameworkCore;
using RakicDental.Interfaces;
using RakicDental.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RakicDental.Repository
{
    public class DentistRepository : IDentistRepository
    {
        private readonly AppDbContext _context;
        public DentistRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Dentist dentist)
        {
            _context.Add(dentist);
            _context.SaveChanges();
        }

        public void Delete(Dentist dentist)
        {
            _context.Remove(dentist);
            _context.SaveChanges();
        }

        public List<Dentist> GetAll()
        {
            return _context.Dentists.OrderBy(d => d.Name).ToList();
        }

        public Dentist GetOne(int id)
        {
            return _context.Dentists.FirstOrDefault(d => d.Id == id);  
        }

        public void Update(Dentist dentist)
        {
            _context.Entry(dentist).State = EntityState.Modified;

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
