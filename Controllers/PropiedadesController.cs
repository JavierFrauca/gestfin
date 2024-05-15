using Microsoft.AspNetCore.Mvc;
using Gestfin.Dtos;
using Gestfin.Services.Implementations;
using Gestfin.Models;
using Gestfin.Services.Interfaces;

namespace Gestfin.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class PropiedadesController(IPropiedadesService service) : ControllerBase
    {
        private readonly IPropiedadesService _service = service;

        /// <summary>
        /// Retrieves a list of properties for a given community.
        /// </summary>
        /// <param name="comunidadId">The ID of the community.</param>
        /// <returns>A list of property DTOs.</returns>
        [HttpGet("list/{comunidadId}")]
        public async Task<ActionResult<IEnumerable<PropiedadListDto>>> Index(int comunidadId)
        {
            var result = await _service.ListAsync(comunidadId);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a property by its ID.
        /// </summary>
        /// <param name="propiedadId">The ID of the property.</param>
        /// <returns>The property DTO.</returns>
        [HttpGet("{propiedadId}")]
        public async Task<ActionResult<IEnumerable<PropiedadEditDto>>> GetById(int propiedadId)
        {
            var (status, datareturn, messages) = await _service.ReadAsync(propiedadId);
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
        /// Adds a new property.
        /// </summary>
        /// <param name="data">The data of the property to be added.</param>
        /// <returns>The added property DTO.</returns>
        [HttpPost("")]
        public async Task<ActionResult> Add(PropiedadAddDto data)
        {
            var (status, datareturn, messages) = await _service.AddAsync(data);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }

        /// <summary>
        /// Updates a property by its ID.
        /// </summary>
        /// <param name="propiedadId">The ID of the property to be updated.</param>
        /// <param name="data">The updated data of the property.</param>
        /// <returns>The updated property DTO.</returns>
        [HttpPut("{propiedadId}")]
        public async Task<ActionResult> Write(int propiedadId, PropiedadEditDto data)
        {
            var (status, datareturn, messages) = await _service.WriteAsync(propiedadId, data);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }

        /// <summary>
        /// Deletes a property by its ID.
        /// </summary>
        /// <param name="propiedadId">The ID of the property to be deleted.</param>
        /// <returns>The deleted property DTO.</returns>
        [HttpDelete("{propiedadId}")]
        public async Task<ActionResult> Delete(int propiedadId)
        {
            var (status, datareturn, messages) = await _service.DeleteAsync(propiedadId);
            if(status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }
    }
}
