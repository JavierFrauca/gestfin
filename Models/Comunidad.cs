using System.ComponentModel.DataAnnotations;

namespace Gestfin.Models
{
    public class Comunidad
    {
        [Key]
        public int ComunidadId { get; set; }
        public string Nombre { get; set; }
        public string CIF { get; set; }
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
        public Propiedad Propiedades { get; set; }
        public Reparto Repartos { get; set; }
        public Concepto Conceptos { get; set; }

    }
}
