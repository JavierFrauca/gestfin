using Gestfin.Models;
using System.ComponentModel.DataAnnotations;

namespace Gestfin.Dtos
{
    public class ComunidadListDto
    {
        public int ComunidadId { get; set; }
        public string CIF { get; set; }
        public string Nombre { get; set; }
    }
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
    public class ComunidadEditDto
    {
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
        public Reparto Repartos { get; set; }
        public Concepto Conceptos { get; set; }
    }
}        /// 