using AutoMapper;
using Gestfin.Dtos;
using Gestfin.Mappers;
using Gestfin.Models;
using Gestfin.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestfin.Services.Implementations
{
    public class RecibosService(MainDB context, IMapper mapper) : IRecibosService
    {
        private MainDB Context { get; } = context;
        private IMapper Mapper { get; } = mapper;

        public virtual async Task<List<ReciboListDto>> ListAsync(int propiedadId)
        {
            var list = await Context.Recibos.Where(x => x.PropiedadId == propiedadId).ToListAsync();
            var listDto = Mapper.Map<List<ReciboListDto>>(list);
            return listDto;
        }
        public virtual async Task<(bool status, ReciboEditDto datareturn, List<string> messages)> AddAsync(ReciboAddDto data)
        {
            var dataMapped = Mapper.Map<Recibo>(data);
            var result = await Context.Set<Recibo>().AddAsync(dataMapped);
            if (result == null)
            {
                return (false, new ReciboEditDto(), ["Fallo agregando registro"]);
            }
            await Context.SaveChangesAsync();
            var resultMapped = Mapper.Map<ReciboEditDto>(dataMapped);
            return (true, resultMapped, []);
        }

        public virtual async Task<(bool status, ReciboEditDto datareturn, List<string> messages)> DeleteAsync(int ReciboId)
        {
            var read = await Context.Recibos.FindAsync(ReciboId);
            if (read == null)
            {
                return (false, new ReciboEditDto(), ["Registro no encontrado"]);
            }
            var readMapped = Mapper.Map<ReciboEditDto>(read);
            Context.Recibos.Remove(read);
            await Context.SaveChangesAsync();
            return (true, readMapped, []);
        }
        public virtual async Task<(bool status, ReciboEditDto datareturn, List<string> messages)> ReadAsync(int ReciboId)
        {
            var read = await Context.Set<Recibo>().FindAsync(ReciboId);
            if (read == null)
            {
                return (false, new ReciboEditDto(), ["No se localizó el registro"]);
            }
            var readMapped = Mapper.Map<ReciboEditDto>(read);
            return (true, readMapped, []);
        }

        public virtual async Task<(bool status, ReciboEditDto datareturn, List<string> messages)> WriteAsync(int ReciboId, ReciboEditDto data)
        {
            (bool result, string[] messages) = Validate(data);
            if (result == false)
            {
                return (false, data, messages.ToList());
            }
            var dataOrigin = await Context.Recibos.FindAsync(ReciboId);
            if (dataOrigin == null)
            {
                return (false, data, ["No se localizó el registro a modificar"]);
            }
            var dataMapped = Mapper.Map(data, dataOrigin);
            Context.Recibos.Update(dataMapped);
            await Context.SaveChangesAsync();
            return (true, data, []);
        }
        public virtual (bool, string[]) Validate(ReciboEditDto data)
        {
            return (true, [""]);
        }
    }
}
