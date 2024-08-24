using RakicDental.Models;
using System.Collections.Generic;

namespace RakicDental.Interfaces
{
    public interface ITreatmentsRepository
    {
        List<Treatment> GetAll();
        Treatment GetOne(int id);
        void Update(Treatment treatment);
        void Delete(Treatment treatment);
        void Create(Treatment treatment);
    }
}
