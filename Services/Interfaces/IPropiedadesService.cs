using Gestfin.Dtos;

namespace Gestfin.Services.Interfaces
{
    public interface IPropiedadesService
    {
        Task<List<PropiedadListDto>> ListAsync(int comunidadId);
        Task<(bool status, PropiedadEditDto datareturn, List<string> messages)> ReadAsync(int comunidadId);
        Task<(bool status, PropiedadEditDto datareturn, List<string> messages)> WriteAsync(int propiedadId, PropiedadEditDto data);
        Task<(bool status, PropiedadEditDto datareturn, List<string> messages)> DeleteAsync(int propiedadId);
        Task<(bool status, PropiedadEditDto datareturn, List<string> messages)> AddAsync(PropiedadAddDto data);
        (bool, string[]) Validate(PropiedadEditDto data);
    }
}
