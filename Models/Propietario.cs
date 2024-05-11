using System.ComponentModel.DataAnnotations;

namespace Gestfin.Models
{
    public class Propietario
    {
        [Key]
        public int PropietarioId { get; set; }
        public string Nombre { get; set; }
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
        public string Email {  get; set; }
        public PropietarioPropiedad Propiedades { get; set; }
    }
}
