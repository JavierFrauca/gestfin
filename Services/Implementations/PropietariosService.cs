using AutoMapper;
using Gestfin.Dtos;
using Gestfin.Mappers;
using Gestfin.Models;
using Gestfin.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestfin.Services.Implementations
{
    public class PropietariosService(MainDB context, IMapper mapper) : IPropietariosService
    {
        private MainDB Context { get; } = context;
        private IMapper Mapper { get; } = mapper;

        public virtual async Task<List<PropietarioListDto>> ListAsync()
        {
            var list = await Context.Propietarios.ToListAsync();
            var listDto = Mapper.Map<List<PropietarioListDto>>(list);
            return listDto;
        }

        public virtual async Task<List<PropietarioListDto>> ListAsync(int propiedadId)
        {
            var list = await Context.Propietarios.Where(x => x.PropietarioId == propiedadId).ToListAsync();
            var listDto = Mapper.Map<List<PropietarioListDto>>(list);
            return listDto;
        }
        public virtual async Task<(bool status, PropietarioEditDto datareturn, List<string> messages)> AddAsync(PropietarioAddDto data)
        {
            var dataMapped = Mapper.Map<Propietario>(data);
            var result = await Context.Set<Propietario>().AddAsync(dataMapped);
            if (result == null)
            {
                return (false, new PropietarioEditDto(), ["Fallo agregando registro"]);
            }
            await Context.SaveChangesAsync();
            var resultMapped = Mapper.Map<PropietarioEditDto>(dataMapped);
            return (true, resultMapped, []);
        }

        public virtual async Task<(bool status, PropietarioEditDto datareturn, List<string> messages)> DeleteAsync(int PropietarioId)
        {
            var read = await Context.Propietarios.FindAsync(PropietarioId);
            if (read == null)
            {
                return (false, new PropietarioEditDto(), ["Registro no encontrado"]);
            }
            var readMapped = Mapper.Map<PropietarioEditDto>(read);
            Context.Propietarios.Remove(read);
            await Context.SaveChangesAsync();
            return (true, readMapped, []);
        }
        public virtual async Task<(bool status, PropietarioEditDto datareturn, List<string> messages)> ReadAsync(int PropietarioId)
        {
            var read = await Context.Set<Propietario>().FindAsync(PropietarioId);
            if (read == null)
            {
                return (false, new PropietarioEditDto(), ["No se localizó el registro"]);
            }
            var readMapped = Mapper.Map<PropietarioEditDto>(read);
            return (true, readMapped, []);
        }

        public virtual async Task<(bool status, PropietarioEditDto datareturn, List<string> messages)> WriteAsync(int PropietarioId, PropietarioEditDto data)
        {
            (bool result, string[] messages) = Validate(data);
            if (result == false)
            {
                return (false, data, messages.ToList());
            }
            var dataOrigin = await Context.Propietarios.FindAsync(PropietarioId);
            if (dataOrigin == null)
            {
                return (false, data, ["No se localizó el registro a modificar"]);
            }
            var dataMapped = Mapper.Map(data, dataOrigin);
            Context.Propietarios.Update(dataMapped);
            await Context.SaveChangesAsync();
            return (true, data, []);
        }
        public virtual (bool, string[]) Validate(PropietarioEditDto data)
        {
            return (true, [""]);
        }
    }
}
