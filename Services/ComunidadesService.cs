using AutoMapper;
using Gestfin.Dtos;
using Gestfin.Models;

namespace Gestfin.Services
{
    public class ComunidadesService(MainDB context,IMapper mapper) : CommonService<Comunidad, ComunidadListDto, ComunidadAddDto, ComunidadReadWriteDto>(context, mapper)
    {
        public override (bool, string[]) Validate(ComunidadReadWriteDto data)
        {
            return (true, []);
        }
    }
}
