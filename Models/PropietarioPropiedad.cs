using Microsoft.EntityFrameworkCore;

namespace Gestfin.Models
{
    public class PropietarioPropiedad
    {
        public int Id { get; set; }
        public int PropietarioId { get; set; }
        public int PropiedadId {  get; set; }
        [Precision(18, 6)]
        public decimal Coeficiente { get; set; }    
        public bool Principal {  get; set; }
        public DateTime FechaInicio { get; set; }   
        public DateTime FechaFin {  get; set; }
    }
}
