using Gestfin.Dtos;

namespace Gestfin.Services.Interfaces
{
    public interface IRepartosService
    {
        Task<List<RepartoListDto>> ListAsync(int comunidadId);
        Task<(bool status, RepartoEditDto datareturn, List<string> messages)> ReadAsync(int propiedadId);
        Task<(bool status, RepartoEditDto datareturn, List<string> messages)> WriteAsync(int propietarioId, RepartoEditDto data);
        Task<(bool status, RepartoEditDto datareturn, List<string> messages)> DeleteAsync(int propietarioId);
        Task<(bool status, RepartoEditDto datareturn, List<string> messages)> AddAsync(RepartoAddDto data);
        (bool, string[]) Validate(RepartoEditDto data);
    }
}