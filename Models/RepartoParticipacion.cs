using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Gestfin.Models
{
    public class RepartoParticipacion
    {
        [Key]
        public int RepartoParticipacionId { get; set; }
        public int ComunidadId {  get; set; }
        public int PropiedadId { get; set; }
        public int RepartoId {  get; set; }
        [Precision(18, 6)]
        public decimal Participacion {  get; set; }
    }
}
