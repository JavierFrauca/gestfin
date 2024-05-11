using System.ComponentModel.DataAnnotations;

namespace Gestfin.Models
{
    public class ReciboPago
    {
        [Key]
        public int ReciboPagoId { get; set; }
        public int ReciboId { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public ReciboMetodoPago MetodoPago { get; set; }
    }
}
