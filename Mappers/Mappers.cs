using AutoMapper;
using Gestfin.Dtos;
using Gestfin.Models;

namespace Gestfin.Mappers
{
    public class Mappers:Profile
    {
        public Mappers()
        {
            CreateMap<Comunidad, ComunidadListDto>();
            CreateMap<ComunidadAddDto, Comunidad>();
            CreateMap<ComunidadEditDto, Comunidad>().ReverseMap();

            CreateMap<Propiedad, PropiedadListDto>();
            CreateMap<PropiedadAddDto, Propiedad>();
            CreateMap<PropiedadEditDto, Propiedad>().ReverseMap();
            
            CreateMap<Propietario, PropietarioListDto>();
            CreateMap<PropietarioAddDto, Propietario>();
            CreateMap<PropietarioEditDto, Propietario>().ReverseMap();

            CreateMap<Recibo, ReciboListDto>();
            CreateMap<ReciboAddDto, Recibo>();
            CreateMap<ReciboEditDto, Recibo>().ReverseMap();

            CreateMap<Reparto, RepartoListDto>();
            CreateMap<RepartoAddDto, Reparto>();
            CreateMap<RepartoEditDto, Reparto>().ReverseMap();
        }
    }
}
