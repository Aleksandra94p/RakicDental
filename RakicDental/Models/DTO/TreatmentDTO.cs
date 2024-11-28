using System;

namespace RakicDental.Models.DTO
{
    public class TreatmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int DentistId { get; set; }
        public string DentistName { get; set; }
        public string DentistLastName { get; set; }
        public string DentistSpecialization { get; set; }

    }
}
