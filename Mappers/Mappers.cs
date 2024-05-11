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
        }
    }
}
