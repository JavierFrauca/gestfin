namespace Gestfin.Dtos
{
    public class ReciboDetalleListDto
    {
        public int ReciboDetalleId { get; set; }
        public string Texto { get; set; }
        public decimal Importe { get; set; }
    }
    public class ReciboDetalleAddDto
    {
        public int ReciboId { get; set; }
        public string Texto { get; set; }
        public decimal Importe { get; set; }

    }
    public class ReciboDetalleEditDto
    {
        public int ReciboId { get; set; }
        public string Texto { get; set; }
        public decimal Importe { get; set; }
    }
}
