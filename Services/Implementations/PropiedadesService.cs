using AutoMapper;
using Gestfin.Dtos;
using Gestfin.Mappers;
using Gestfin.Models;
using Gestfin.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestfin.Services.Implementations
{
    public class PropiedadesService(MainDB context, IMapper mapper): IPropiedadesService
    {
        private MainDB Context { get; } = context;
        private IMapper Mapper { get; } = mapper;

    public virtual async Task<List<PropiedadListDto>> ListAsync(int comunidadId)
    {
        var list = await Context.Propiedades.Where(x => x.ComunidadId == comunidadId).ToListAsync();
        var listDto = Mapper.Map<List<PropiedadListDto>>(list);
        return listDto;
    }
    public virtual async Task<(bool status, PropiedadEditDto datareturn, List<string> messages)> AddAsync(PropiedadAddDto data)
    {
        var dataMapped = Mapper.Map<Propiedad>(data);
        var result = await Context.Set<Propiedad>().AddAsync(dataMapped);
        if (result == null)
        {
            return (false, new PropiedadEditDto(), ["Fallo agregando registro"]);
        }
        await Context.SaveChangesAsync();
        var resultMapped = Mapper.Map<PropiedadEditDto>(dataMapped);
        return (true, resultMapped, []);
    }

    public virtual async Task<(bool status, PropiedadEditDto datareturn, List<string> messages)> DeleteAsync(int propiedadId)
    {
        var read = await Context.Propiedades.FindAsync(propiedadId);
        if (read == null)
        {
            return (false, new PropiedadEditDto(), ["Registro no encontrado"]);
        }
        var readMapped = Mapper.Map<PropiedadEditDto>(read);
        Context.Propiedades.Remove(read);
        await Context.SaveChangesAsync();
        return (true, readMapped, []);
    }
    public virtual async Task<(bool status, PropiedadEditDto datareturn, List<string> messages)> ReadAsync(int propiedadId)
    {
        var read = await Context.Set<Propiedad>().FindAsync(propiedadId);
        if (read == null)
        {
            return (false, new PropiedadEditDto(), ["No se localizó el registro"]);
        }
        var readMapped = Mapper.Map<PropiedadEditDto>(read);
        return (true, readMapped, []);
    }

    public virtual async Task<(bool status, PropiedadEditDto datareturn, List<string> messages)> WriteAsync(int propiedadId, PropiedadEditDto data)
    {
        (bool result, string[] messages) = Validate(data);
        if (result == false)
        {
            return (false, data, messages.ToList());
        }
        var dataOrigin = await Context.Propiedades.FindAsync(propiedadId);
        if (dataOrigin == null)
        {
            return (false, data, ["No se localizó el registro a modificar"]);
        }
        var dataMapped = Mapper.Map(data, dataOrigin);
        Context.Propiedades.Update(dataMapped);
        await Context.SaveChangesAsync();
        return (true, data, []);
    }
    public virtual (bool, string[]) Validate(PropiedadEditDto data)
    {
        return (true, [""]);
    }
}
}
