using RakicDental.Models;
using System.Collections.Generic;

namespace RakicDental.Interfaces
{
    public interface IDentistRepository
    {
        List<Dentist> GetAll();
        Dentist GetOne(int id);
        void Create(Dentist dentist);
        void Update(Dentist dentist);
        void Delete(Dentist dentist);

    }
}
