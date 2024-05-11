using Microsoft.AspNetCore.Mvc;
using Gestfin.Dtos;
using Gestfin.Services.Implementations;
using Gestfin.Models;
using Gestfin.Services.Interfaces;

namespace Gestfin.Controllers
{
    [ApiController]
    [Route("api/v1/comunidad")]
    public class PropiedadesController(IPropiedadesService service) : ControllerBase
    {
        private readonly IPropiedadesService _service = service;

        // GET: Propiedades
        [HttpGet("{comunidadId}/propiedad/list")]
        public async Task<ActionResult<IEnumerable<PropiedadListDto>>> Index(int comunidadId)
        {
            var result = await _service.ListAsync(comunidadId);
            return Ok(result);
        }
        // GET: Propiedad
        [HttpGet("{ComunidadId}/propiedad/{propiedadId}")]
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
        //POST: Propiedad
        [HttpPost("{ComunidadId}/propiedad")]
        public async Task<ActionResult> Add(PropiedadAddDto data)
        {
            var (status, datareturn, messages) = await _service.AddAsync(data);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }
        [HttpPut("{ComunidadId}/propiedad/{propiedadId}")]
        public async Task<ActionResult> Write(int propiedadId, PropiedadEditDto data)
        {
            var (status, datareturn, messages) = await _service.WriteAsync(propiedadId, data);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }
        [HttpDelete("{ComunidadId}/propiedad/{propiedadId}")]
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
