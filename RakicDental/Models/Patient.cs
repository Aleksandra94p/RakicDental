using System.Collections;
using System.Collections.Generic;

namespace RakicDental.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection <Treatment> Treatments { get; set; }

    }
}
