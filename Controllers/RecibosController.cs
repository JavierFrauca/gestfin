using Microsoft.AspNetCore.Mvc;
using Gestfin.Dtos;
using Gestfin.Services.Implementations;
using Gestfin.Models;
using Gestfin.Services.Interfaces;
using System.Runtime.InteropServices.ObjectiveC;

namespace Gestfin.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class RecibosController(IRecibosService service) : ControllerBase
    {
        private readonly IRecibosService _service = service;

        /// <summary>
        /// Obtiene una lista de recibos asociados a una propiedad.
        /// </summary>
        /// <param name="propiedadId">El ID de la propiedad.</param>
        /// <returns>Una lista de objetos ReciboListDto.</returns>
        [HttpGet("list/{propiedadId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReciboListDto>))] // OK
        [ProducesResponseType(404)] // NotFound
        public async Task<ActionResult<IEnumerable<ReciboListDto>>> Index(int propiedadId)
        {
            var result = await _service.ListAsync(propiedadId);
            return Ok(result);
        }

        /// <summary>
        /// Obtiene un recibo por su ID.
        /// </summary>
        /// <param name="reciboId">El ID del recibo.</param>
        /// <returns>Un objeto ReciboEditDto.</returns>
        [HttpGet("{propiedadId}")]
        public async Task<ActionResult<IEnumerable<ReciboEditDto>>> GetById(int reciboId)
        {
            var (status, datareturn, messages) = await _service.ReadAsync(reciboId);
            if (status == false)
            {
                return NotFound(messages.ToList());
            }
            else
            {
                return Ok(datareturn);
            }
        }

        /// <summary>
        /// Agrega un nuevo recibo.
        /// </summary>
        /// <param name="data">Los datos del recibo a agregar.</param>
        /// <returns>El recibo agregado.</returns>
        [HttpPost("")]
        public async Task<ActionResult> Add(ReciboAddDto data)
        {
            var (status, datareturn, messages) = await _service.AddAsync(data);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }

        /// <summary>
        /// Actualiza un recibo existente.
        /// </summary>
        /// <param name="reciboId">El ID del recibo a actualizar.</param>
        /// <param name="data">Los nuevos datos del recibo.</param>
        /// <returns>El recibo actualizado.</returns>
        [HttpPut("{reciboId}")]
        public async Task<ActionResult> Write(int reciboId, ReciboEditDto data)
        {
            var (status, datareturn, messages) = await _service.WriteAsync(reciboId, data);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }

        /// <summary>
        /// Elimina un recibo existente.
        /// </summary>
        /// <param name="reciboId">El ID del recibo a eliminar.</param>
        /// <returns>El recibo eliminado.</returns>
        [HttpDelete("{reciboId}")]
        public async Task<ActionResult> Delete(int reciboId)
        {
            var (status, datareturn, messages) = await _service.DeleteAsync(reciboId);
            if(status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }
    }
}
