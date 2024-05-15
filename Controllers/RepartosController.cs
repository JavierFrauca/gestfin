using Gestfin.Dtos;
using Gestfin.Services.Implementations;
using Gestfin.Models;
using Gestfin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gestfin.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class RepartosController : ControllerBase
    {
        private readonly IRepartosService _service;

        public RepartosController(IRepartosService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves a list of repartos based on the comunidadId.
        /// </summary>
        /// <param name="comunidadId">The ID of the comunidad.</param>
        /// <returns>A list of RepartoListDto objects.</returns>
        [HttpGet("/list/{comunidadId}")]
        public async Task<ActionResult<IEnumerable<RepartoListDto>>> Index(int comunidadId)
        {
            var result = await _service.ListAsync(comunidadId);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a reparto based on the repartoId.
        /// </summary>
        /// <param name="repartoId">The ID of the reparto.</param>
        /// <returns>A RepartoEditDto object.</returns>
        [HttpGet("{repartoId}")]
        public async Task<ActionResult<IEnumerable<RepartoEditDto>>> GetById(int repartoId)
        {
            var (status, datareturn, messages) = await _service.ReadAsync(repartoId);
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
        /// Adds a new reparto.
        /// </summary>
        /// <param name="data">The RepartoAddDto object containing the reparto data.</param>
        /// <returns>An ActionResult object.</returns>
        [HttpPost("")]
        public async Task<ActionResult> Add(RepartoAddDto data)
        {
            var (status, datareturn, messages) = await _service.AddAsync(data);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }

        /// <summary>
        /// Updates an existing reparto.
        /// </summary>
        /// <param name="repartoId">The ID of the reparto.</param>
        /// <param name="data">The RepartoEditDto object containing the updated reparto data.</param>
        /// <returns>An ActionResult object.</returns>
        [HttpPut("{repartoId}")]
        public async Task<ActionResult> Write(int repartoId, RepartoEditDto data)
        {
            var (status, datareturn, messages) = await _service.WriteAsync(repartoId, data);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }

        /// <summary>
        /// Deletes a reparto based on the repartoId.
        /// </summary>
        /// <param name="repartoId">The ID of the reparto.</param>
        /// <returns>An ActionResult object.</returns>
        [HttpDelete("{repartoId}")]
        public async Task<ActionResult> Delete(int repartoId)
        {
            var (status, datareturn, messages) = await _service.DeleteAsync(repartoId);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }
    }
}