using System.ComponentModel.DataAnnotations;

namespace Gestfin.Models
{
    public enum ReciboTipo
    {
        [Key]
        Ordinario = 0,
        Derrama = 1,
        Calefaccion = 2,
        AguaCaliente = 3,
        Otros = 4
    }
}
