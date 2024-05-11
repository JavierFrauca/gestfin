using Gestfin.Models;
using System.ComponentModel.DataAnnotations;

namespace Gestfin.Dtos
{
    public class PropiedadListDto
    {
        public int IdPropiedad { get; set; }
        public string Codigo { get; set; }
        [MaxLength(2)]
        public string TipoVia { get; set; }
        [MaxLength(150)]
        public string Calle { get; set; }
        [MaxLength(10)]
        public string Numero { get; set; }
        [MaxLength(10)]
        public string Piso { get; set; }
        [MaxLength(10)]
        public string Portal { get; set; }
        [MaxLength(10)]
        public string Puerta { get; set; }
    }
    public class PropiedadAddDto
    {
        public int ComunidadId { get; set; }
        public string Codigo { get; set; }
        [MaxLength(2)]
        public string TipoVia { get; set; }
        [MaxLength(150)]
        public string Calle { get; set; }
        [MaxLength(10)]
        public string Numero { get; set; }
        [MaxLength(10)]
        public string Piso { get; set; }
        [MaxLength(10)]
        public string Portal { get; set; }
        [MaxLength(10)]
        public string Puerta { get; set; }
    }
    public class PropiedadEditDto
    {
        public string Codigo { get; set; }
        [MaxLength(2)]
        public string TipoVia { get; set; }
        [MaxLength(150)]
        public string Calle { get; set; }
        [MaxLength(10)]
        public string Numero { get; set; }
        [MaxLength(10)]
        public string Piso { get; set; }
        [MaxLength(10)]
        public string Portal { get; set; }
        [MaxLength(10)]
        public string Puerta { get; set; }
        public PropietarioPropiedad Propietarios { get; set; }
        public RepartoParticipacion Repartos { get; set; }
    }
}
