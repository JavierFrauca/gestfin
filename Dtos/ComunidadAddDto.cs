using Gestfin.Models;
using System.ComponentModel.DataAnnotations;

namespace Gestfin.Dtos
{
    public class ComunidadAddDto
    {
        public string Nombre { get; set; }
        public string CIF { get; set; }
        public string TipoVia { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Piso { get; set; }
        public string Portal { get; set; }
        public string Puerta { get; set; }
    }
}
