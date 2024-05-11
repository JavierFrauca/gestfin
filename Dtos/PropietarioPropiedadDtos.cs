using Microsoft.EntityFrameworkCore;

namespace Gestfin.Dtos
{
    public class PropietarioPropiedadListDto
    {
        public int PropietarioPropiedadId { get; set; }
        [Precision(18, 6)]
        public decimal Coeficiente { get; set; }
        public bool Principal { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
    public class PropietarioPropiedadAddDto
    {
        public int PropietarioId { get; set; }
        public int PropiedadId { get; set; }
        [Precision(18, 6)]
        public decimal Coeficiente { get; set; }
        public bool Principal { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
    public class PropietarioPropiedadEditDto
    {
        public int PropietarioId { get; set; }
        public int PropiedadId { get; set; }
        [Precision(18, 6)]
        public decimal Coeficiente { get; set; }
        public bool Principal { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
