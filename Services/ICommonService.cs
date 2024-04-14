
namespace Gestfin.Services
{
    public interface ICommonService<TEntity,TListDto, TAddDto,TEditDto>
    {
        Task<List<TListDto>> ListAsync();
        Task<(bool status, TEditDto datareturn, List<string> messages)> ReadAsync(int id);
        Task<(bool status, TEditDto datareturn, List<string> messages)> WriteAsync(int id,TEditDto data);
        Task<(bool status, TEditDto datareturn, List<string> messages)> DeleteAsync(int id);
        Task<(bool status, TEditDto datareturn, List<string> messages)> AddAsync(TAddDto data);
        (bool, string[]) Validate(TEditDto data);
    }
}
