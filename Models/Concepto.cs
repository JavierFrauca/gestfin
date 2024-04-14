namespace Gestfin.Models
{
    public class Concepto
    {
        public int Id { get; set; }
        public int ComunidadId {  get; set; }
        public int RepartoId {  get; set; }
        public string Descripcion { get; set; }
    }
}
