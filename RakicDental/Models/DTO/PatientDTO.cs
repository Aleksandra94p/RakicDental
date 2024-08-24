using System.Collections.Generic;

namespace RakicDental.Models.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection <TreatmentDTO> Treatments { get; set; }

    }
}
