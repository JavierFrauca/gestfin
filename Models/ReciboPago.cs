namespace Gestfin.Models
{
    public class ReciboPago
    {
        public int Id { get; set; }
        public int ReciboId { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public ReciboMetodoPago MetodoPago { get; set; }
    }
}
