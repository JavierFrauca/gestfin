using Microsoft.EntityFrameworkCore;

namespace Gestfin.Dtos
{
    public class RepartoParticipacionListDto
    {
        public int RepartoParticipacionId { get; set; }
        [Precision(18, 6)]
        public decimal Participacion { get; set; }
    }
    public class RepartoParticipacionAddDto 
    {
        public int ComunidadId { get; set; }
        public int PropiedadId { get; set; }
        public int RepartoId { get; set; }
        [Precision(18, 6)]
        public decimal Participacion { get; set; }
    }
    public class RepartoParticipacionEditDto
    {
        public int ComunidadId { get; set; }
        public int PropiedadId { get; set; }
        public int RepartoId { get; set; }
        [Precision(18, 6)]
        public decimal Participacion { get; set; }
    }
}
