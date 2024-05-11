using Gestfin.Dtos;

namespace Gestfin.Services.Interfaces
{
    public interface IPropietariosService
    {
        Task<List<PropietarioListDto>> ListAsync(int comunidadId);
        Task<(bool status, PropietarioEditDto datareturn, List<string> messages)> ReadAsync(int propiedadId);
        Task<(bool status, PropietarioEditDto datareturn, List<string> messages)> WriteAsync(int propietarioId, PropietarioEditDto data);
        Task<(bool status, PropietarioEditDto datareturn, List<string> messages)> DeleteAsync(int propietarioId);
        Task<(bool status, PropietarioEditDto datareturn, List<string> messages)> AddAsync(PropietarioAddDto data);
        (bool, string[]) Validate(PropietarioEditDto data);
    }
}
