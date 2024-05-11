using System.ComponentModel.DataAnnotations;

namespace Gestfin.Models
{
    public enum ReciboMetodoPago
    {
        [Key]
        Efectivo = 0,
        Domiciliado = 1,
        Embargo = 2,
        Compensado = 3
    }
}
