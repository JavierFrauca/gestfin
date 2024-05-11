using Gestfin.Models;

namespace Gestfin.Dtos
{
    public class RepartoListDto
    {
        public int RepartoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Enteros { get; set; }
    }
    public class RepartoAddDto
    {
        public string Descripcion { get; set; }
        public decimal Enteros { get; set; }
    }
    public class RepartoditDto
    {
        public int ComunidadId { get; set; }
        public string Descripcion { get; set; }
        public decimal Enteros { get; set; }
        RepartoParticipacion Participacion { get; set; }
    }
}
