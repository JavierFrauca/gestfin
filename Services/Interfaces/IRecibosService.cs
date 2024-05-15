using Gestfin.Dtos;

public interface IRecibosService
{
        Task<List<ReciboListDto>> ListAsync(int PropiedadId);
        Task<(bool status, ReciboEditDto datareturn, List<string> messages)> ReadAsync(int reciboId);
        Task<(bool status, ReciboEditDto datareturn, List<string> messages)> WriteAsync(int reciboId, ReciboEditDto data);
        Task<(bool status, ReciboEditDto datareturn, List<string> messages)> DeleteAsync(int reciboId);
        Task<(bool status, ReciboEditDto datareturn, List<string> messages)> AddAsync(ReciboAddDto data);
        (bool, string[]) Validate(ReciboEditDto data);
}