using System;

namespace RakicDental.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }

        public Dentist Dentist { get; set; }
        public int DentistId { get; set; }

    }
}
