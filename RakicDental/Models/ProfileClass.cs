using AutoMapper;
using RakicDental.Models.DTO;

namespace RakicDental.Models
{
    public class ProfileClass : Profile
    {
        public ProfileClass()
        {
            CreateMap<Dentist, DentistDTO>();
            CreateMap<Patient, PatientDTO>();
            CreateMap<Treatment, TreatmentDTO>()
                 .ForMember(dest => dest.DentistId, opt => opt.MapFrom(src => src.DentistId))
                 .ForMember(dest => dest.DentistName, opt => opt.MapFrom(src => src.Dentist.Name))
                 .ForMember(dest => dest.DentistLastName, opt => opt.MapFrom(src => src.Dentist.LastName))
                 .ForMember(dest => dest.DentistSpecialization, opt => opt.MapFrom(src => src.Dentist.Specialization));
        }
    }
}
