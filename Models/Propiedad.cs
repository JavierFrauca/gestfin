using System.ComponentModel.DataAnnotations;

namespace Gestfin.Models
{
    public class Propiedad
    {
        public int Id {  get; set; }
        public int ComundiadId { get; set; }
        public string Codigo { get; set;}
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
