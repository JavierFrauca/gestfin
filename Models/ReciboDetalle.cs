namespace Gestfin.Models
{
    public class ReciboDetalle
    {
        public int Id { get; set; }
        public int ReciboId {  get; set; }
        public string Texto {  get; set; }
        public decimal Importe { get; set; }
    }
}
