using AutoMapper;
using Gestfin.Dtos;
using Gestfin.Models;
using Gestfin.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestfin.Services.Implementations
{
    public class ComunidadesService(MainDB context, IMapper mapper) : IComunidadesService
    {
        private MainDB Context { get; } = context;
        private IMapper Mapper { get; } = mapper;

        public async Task<List<ComunidadListDto>> ListAsync()
        {
            var list = await Context.Comunidades.AsNoTracking().ToListAsync();
            var listDto = Mapper.Map<List<ComunidadListDto>>(list);
            return listDto;
        }
        public async Task<(bool status, ComunidadEditDto datareturn, List<string> messages)> AddAsync(ComunidadAddDto data)
        {
            var dataMapped = Mapper.Map<Comunidad>(data);
            var result = await Context.Set<Comunidad>().AddAsync(dataMapped);
            if (result == null)
            {
                return (false, new ComunidadEditDto(), ["Fallo agregando registro"]);
            }
            await Context.SaveChangesAsync();
            var resultMapped = Mapper.Map<ComunidadEditDto>(dataMapped);
            return (true, resultMapped, []);
        }

        public async Task<(bool status, ComunidadEditDto datareturn, List<string> messages)> DeleteAsync(int comunidadId)
        {
            var read = await Context.Comunidades.FindAsync(comunidadId);
            if (read == null)
            {
                return (false, new ComunidadEditDto(), ["Registro no encontrado"]);
            }
            var readMapped = Mapper.Map<ComunidadEditDto>(read);
            Context.Comunidades.Remove(read);
            await Context.SaveChangesAsync();
            return (true, readMapped, []);
        }
        public async Task<(bool status, ComunidadEditDto datareturn, List<string> messages)> ReadAsync(int comunidadId)
        {
            var read = await Context.Set<Comunidad>().FindAsync(comunidadId);
            if (read == null)
            {
                return (false, new ComunidadEditDto(), ["No se localizó el registro"]);
            }
            var readMapped = Mapper.Map<ComunidadEditDto>(read);
            return (true, readMapped, []);
        }

        public async Task<(bool status, ComunidadEditDto datareturn, List<string> messages)> WriteAsync(int comunidadId, ComunidadEditDto data)
        {
            (bool result, string[] messages) = Validate(data);
            if (result == false)
            {
                return (false, data, messages.ToList());
            }
            var dataOrigin = await Context.Comunidades.FindAsync(comunidadId);
            if (dataOrigin == null)
            {
                return (false, data, ["No se localizó el registro a modificar"]);
            }
            var dataMapped = Mapper.Map(data, dataOrigin);
            Context.Comunidades.Update(dataMapped);
            await Context.SaveChangesAsync();
            return (true, data, []);
        }
        public (bool, string[]) Validate(ComunidadEditDto data)
        {
            return (true, [""]);
        }
    }
}
