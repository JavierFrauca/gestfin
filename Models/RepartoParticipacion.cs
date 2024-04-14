using Microsoft.EntityFrameworkCore;

namespace Gestfin.Models
{
    public class RepartoParticipacion
    {
        public int Id { get; set; }
        public int ComunidadId {  get; set; }
        public int PropiedadId { get; set; }
        public int RepartoId {  get; set; }
        [Precision(18, 6)]
        public decimal Participacion {  get; set; }
    }
}
