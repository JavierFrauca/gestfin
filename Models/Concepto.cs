using System.ComponentModel.DataAnnotations;

namespace Gestfin.Models
{
    public class Concepto
    {
        [Key]
        public int ConceptoId { get; set; }
        public int ComunidadId {  get; set; }
        public int RepartoId {  get; set; }
        public string Descripcion { get; set; }
    }
}
