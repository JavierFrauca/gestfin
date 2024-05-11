using Gestfin.Models;
using System.ComponentModel.DataAnnotations;

namespace Gestfin.Dtos
{
    public class PropietarioListDto
    {
        public int PropietarioId { get; set; }
        public string Nombre { get; set; }
    }
    public class PropietarioAddDto
    {
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
        public string Email { get; set; }
    }
    public class PropietarioEditDto
    {
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
        public string Email { get; set; }
        public PropietarioPropiedad Propiedades { get; set; }
    }
}
