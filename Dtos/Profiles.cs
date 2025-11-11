using AutoMapper;
using LicenciasAPI.Models;
using LicenciasAPI.Dtos;

namespace LicenciasAPI.Dtos
{
    public class LicenciaProfile : Profile
    {
        public LicenciaProfile()
        {
            CreateMap<LicenciaCreateDto, Licencia>();
            CreateMap<Licencia, LicenciaReadDto>();
            CreateMap<LicenciaUpdateDto, Licencia>();
        }
    }
}

