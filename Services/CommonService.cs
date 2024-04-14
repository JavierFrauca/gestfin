using AutoMapper;
using Gestfin.Dtos;
using Gestfin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Gestfin.Services
{
    public abstract class CommonService<TEntity, TListDto, TAddDto, TEditDto>(MainDB context, IMapper mapper) : ICommonService<TEntity, TListDto, TAddDto, TEditDto>
            where TEntity : class
            where TListDto : class
            where TAddDto : class
            where TEditDto : new()
    {
        private MainDB Context { get; } = context;
        private IMapper Mapper { get; } = mapper;

        public virtual async Task<List<TListDto>> ListAsync()
        {
            var list = await Context.Set<TEntity>().ToListAsync();
            var listDto = Mapper.Map<List<TListDto>>(list);
            return listDto;
        }
        public virtual async Task<(bool status, TEditDto datareturn, List<string> messages)> AddAsync(TAddDto data)
        {
            var dataMapped = Mapper.Map<TEntity>(data);
            var result = await Context.Set<TEntity>().AddAsync(dataMapped);
            if (result == null)
            {
                return (false, new TEditDto(), ["Fallo agregando la comunidad"]);
            }
            await Context.SaveChangesAsync();
            var resultMapped = Mapper.Map<TEditDto>(dataMapped);
            return (true, resultMapped, []);
        }

        public virtual async Task<(bool status, TEditDto datareturn, List<string> messages)> DeleteAsync(int id)
        {
            var read = await Context.Comunidades.FindAsync(id);
            if (read == null)
            {
                return (false, new TEditDto(), ["Registro no encontrado"]);
            }
            var readMapped = Mapper.Map<TEditDto>(read);
            Context.Comunidades.Remove(read);
            await Context.SaveChangesAsync();
            return (true, readMapped, []);
        }
        public virtual async Task<(bool status, TEditDto datareturn, List<string> messages)> ReadAsync(int id)
        {
            var read = await Context.Set<TEntity>().FindAsync(id);
            if (read == null)
            {
                return (false, new TEditDto(), ["No se localizó la comunidad"]);
            }
            var readMapped = Mapper.Map<TEditDto>(read);
            return (true, readMapped, []);
        }

        public virtual async Task<(bool status, TEditDto datareturn, List<string> messages)> WriteAsync(int id, TEditDto data)
        {
            (bool result, string[] messages) = Validate(data);
            if ( result == false)
            {
                return (false, data, messages.ToList());
            }
            var dataOrigin =  await Context.Set<TEntity>().FindAsync(id);
            if (dataOrigin == null)
            {
                return (false, data, ["No se localizó el registro a modificar"]);
            }
            var dataMapped = Mapper.Map(data,dataOrigin);
            Context.Set<TEntity>().Update(dataMapped);
            await Context.SaveChangesAsync();
            return (true, data, []);
        }
        public virtual (bool, string[]) Validate(TEditDto data)
        {
            return (true,[""]) ;
        }

    }
}
