using Gestfin.Dtos;
namespace Gestfin.Services.Interfaces
{
    public interface IComunidadesService
    {
        Task<List<ComunidadListDto>> ListAsync();
        Task<(bool status, ComunidadEditDto datareturn, List<string> messages)> ReadAsync(int comunidadId);
        Task<(bool status, ComunidadEditDto datareturn, List<string> messages)> WriteAsync(int comunidadId, ComunidadEditDto data);
        Task<(bool status, ComunidadEditDto datareturn, List<string> messages)> DeleteAsync(int comunidadId);
        Task<(bool status, ComunidadEditDto datareturn, List<string> messages)> AddAsync(ComunidadAddDto data);
        (bool, string[]) Validate(ComunidadEditDto data);
    }
}

