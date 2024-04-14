using Microsoft.EntityFrameworkCore;

namespace Gestfin.Models
{
    public class Reparto
    {
        public int Id { get; set; }
        public int ComunidadId { get; set; }
        public string Descripcion { get; set; }
        public decimal Enteros {  get; set; }

    }
}
