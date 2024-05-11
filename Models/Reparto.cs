using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Gestfin.Models
{
    public class Reparto
    {
        [Key]
        public int RepartoId { get; set; }
        public int ComunidadId { get; set; }
        public string Descripcion { get; set; }
        public decimal Enteros {  get; set; }
        RepartoParticipacion Participacion { get; set; }
    }
}
