using Gestfin.Models;

namespace Gestfin.Dtos
{
    public class ReciboListDto
    {
        public int ReciboId { get; set; }
        public ReciboTipo Tipo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public ReciboEstado Estado { get; set; }
    }
    public class ReciboAddDto
    {
        public int ComunidadId { get; set; }
        public int PropiedadId { get; set; }
        public ReciboTipo Tipo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
    }
    public class ReciboEditDto
    {
        public int ComunidadId { get; set; }
        public int PropiedadId { get; set; }
        public ReciboTipo Tipo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public ReciboDetalle Detalles { get; set; }
        public ReciboEstado Estado { get; set; }
        public ReciboPago Pago { get; set; }
    }
}
