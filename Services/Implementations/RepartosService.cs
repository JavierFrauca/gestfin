using AutoMapper;
using Gestfin.Dtos;
using Gestfin.Models;
using Gestfin.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestfin.Services.Implementations
{
    public class RepartosService : IRepartosService
    {
        private MainDB Context { get; }
        private IMapper Mapper { get; }

        public RepartosService(MainDB context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public virtual async Task<List<RepartoListDto>> ListAsync(int comunidadId)
        {
            var list = await Context.Repartos.Where(x => x.ComunidadId == comunidadId).ToListAsync();
            var listDto = Mapper.Map<List<RepartoListDto>>(list);
            return listDto;
        }

        public virtual async Task<(bool status, RepartoEditDto datareturn, List<string> messages)> AddAsync(RepartoAddDto data)
        {
            var dataMapped = Mapper.Map<Reparto>(data);
            var result = await Context.Set<Reparto>().AddAsync(dataMapped);
            if (result == null)
            {
                return (false, new RepartoEditDto(), new List<string> { "Fallo agregando registro" });
            }
            await Context.SaveChangesAsync();
            var resultMapped = Mapper.Map<RepartoEditDto>(dataMapped);
            return (true, resultMapped, new List<string>());
        }

        public virtual async Task<(bool status, RepartoEditDto datareturn, List<string> messages)> DeleteAsync(int repartoId)
        {
            var read = await Context.Repartos.FindAsync(repartoId);
            if (read == null)
            {
                return (false, new RepartoEditDto(), new List<string> { "Registro no encontrado" });
            }
            var readMapped = Mapper.Map<RepartoEditDto>(read);
            Context.Repartos.Remove(read);
            await Context.SaveChangesAsync();
            return (true, readMapped, new List<string>());
        }

        public virtual async Task<(bool status, RepartoEditDto datareturn, List<string> messages)> ReadAsync(int repartoId)
        {
            var read = await Context.Set<Reparto>().FindAsync(repartoId);
            if (read == null)
            {
                return (false, new RepartoEditDto(), new List<string> { "No se localizó el registro" });
            }
            var readMapped = Mapper.Map<RepartoEditDto>(read);
            return (true, readMapped, new List<string>());
        }

        public virtual async Task<(bool status, RepartoEditDto datareturn, List<string> messages)> WriteAsync(int repartoId, RepartoEditDto data)
        {
            (bool result, string[] messages) = Validate(data);
            if (result == false)
            {
                return (false, data, messages.ToList());
            }
            var dataOrigin = await Context.Repartos.FindAsync(repartoId);
            if (dataOrigin == null)
            {
                return (false, data, new List<string> { "No se localizó el registro a modificar" });
            }
            var dataMapped = Mapper.Map(data, dataOrigin);
            Context.Repartos.Update(dataMapped);
            await Context.SaveChangesAsync();
            return (true, data, new List<string>());
        }

        public virtual (bool, string[]) Validate(RepartoEditDto data)
        {
            return (true, new string[] { "" });
        }
    }
}