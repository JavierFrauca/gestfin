using System.ComponentModel.DataAnnotations;

namespace Gestfin.Models
{
    public class ReciboDetalle
    {
        [Key]
        public int ReciboDetalleId { get; set; }
        public int ReciboId {  get; set; }
        public string Texto {  get; set; }
        public decimal Importe { get; set; }
    }
}
