using RakicDental.Models;
using System.Collections.Generic;

namespace RakicDental.Interfaces
{
    public interface IPatientRepository
    {
        List<Patient> GetAll();
        Patient GetOne(int id);
        List<Patient> GetByName(string name);
        List<Patient> GetAllTreatments();
        void Update(Patient patient);
        void Delete(Patient patient);
        void Create(Patient patient);
    }
}
