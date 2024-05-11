using System.ComponentModel.DataAnnotations;

namespace Gestfin.Models
{
    public enum ReciboEstado
    {
        [Key]
        Generado = 0,
        Remesado = 1,
        Pagado = 2,
        Devuelto = 3,
        Anulado = 4
    }
}
