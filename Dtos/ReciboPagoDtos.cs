using Gestfin.Models;

namespace Gestfin.Dtos
{
    public class ReciboPagoListDto
    {
        public int ReciboPagoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
    }
    public class ReciboPagoAddDto
    {
        public int ReciboId { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
    }
    public class ReciboPagoEditDto
    {
        public int ReciboId { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public ReciboMetodoPago MetodoPago { get; set; }
    }
}
