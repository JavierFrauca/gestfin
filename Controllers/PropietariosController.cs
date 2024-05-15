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
    public class PropietariosController(IPropietariosService service) : ControllerBase
    {
        private readonly IPropietariosService _service = service;

        /// <summary>
        /// Retrieves a collection of PropietarioListDto objects.
        /// </summary>
        /// <returns>An ActionResult containing a collection of PropietarioListDto objects.</returns>
        [HttpGet("/list")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PropietarioListDto>))] // OK
        [ProducesResponseType(404)] // NotFound
        public async Task<ActionResult<IEnumerable<PropietarioListDto>>> Index()
        {
            var result = await _service.ListAsync();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a collection of PropietarioListDto objects by the specified propiedadId.
        /// </summary>
        /// <param name="propiedadId">The ID of the propiedad.</param>
        /// <returns>An ActionResult containing a collection of PropietarioListDto objects if found, or a NotFound result if not found.</returns>
        [HttpGet("/list/{propiedadId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PropietarioListDto>))] // OK
        [ProducesResponseType(404)] // NotFound
        public async Task<ActionResult<IEnumerable<PropietarioListDto>>> Index(int propiedadId)
        {
            var result = await _service.ListAsync(propiedadId);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a collection of ReciboEditDto objects by the specified propietarioId.
        /// </summary>
        /// <param name="propietarioId">The ID of the propietario.</param>
        /// <returns>An ActionResult containing a collection of ReciboEditDto objects if found, or a NotFound result if not found.</returns>
        [HttpGet("{propietarioId}")]
        public async Task<ActionResult<IEnumerable<ReciboEditDto>>> GetById(int propietarioId)
        {
            var (status, datareturn, messages) = await _service.ReadAsync(propietarioId);
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
        /// Adds a new Propietario.
        /// </summary>
        /// <param name="data">The data of the Propietario to be added.</param>
        /// <returns>An ActionResult containing the added Propietario if successful, or a BadRequest result if not successful.</returns>
        [HttpPost("")]
        public async Task<ActionResult> Add(PropietarioAddDto data)
        {
            var (status, datareturn, messages) = await _service.AddAsync(data);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }

        /// <summary>
        /// Updates an existing Propietario.
        /// </summary>
        /// <param name="propietarioId">The ID of the Propietario to be updated.</param>
        /// <param name="data">The updated data of the Propietario.</param>
        /// <returns>An ActionResult containing the updated Propietario if successful, or a BadRequest result if not successful.</returns>
        [HttpPut("{propietarioId}")]
        public async Task<ActionResult> Write(int propietarioId, PropietarioEditDto data)
        {
            var (status, datareturn, messages) = await _service.WriteAsync(propietarioId, data);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }

        /// <summary>
        /// Deletes an existing Propietario.
        /// </summary>
        /// <param name="propietarioId">The ID of the Propietario to be deleted.</param>
        /// <returns>An ActionResult indicating the result of the deletion.</returns>
        [HttpDelete("{propietarioId}")]
        public async Task<ActionResult> Delete(int propietarioId)
        {
            var (status, datareturn, messages) = await _service.DeleteAsync(propietarioId);
            if(status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }
    }
}
