using Microsoft.AspNetCore.Mvc;
using Gestfin.Dtos;
using Gestfin.Services.Implementations;
using Gestfin.Services.Interfaces;

namespace Gestfin.Controllers
{
    [ApiController]
    [Route("api/v1/comunidad")]
    public class ComunidadesController(IComunidadesService service) : ControllerBase
    {
        private readonly IComunidadesService _service = service;

        // GET: Comunidades
        [HttpGet("/List")]
        public async Task<ActionResult<IEnumerable<ComunidadListDto>>> Index()
        {
            var result = await _service.ListAsync();
            return Ok(result);
        }
        // GET: Comunidad
        [HttpGet("{comunidadid}")]
        public async Task<ActionResult<IEnumerable<ComunidadEditDto>>> GetById(int comunidadid)
        {
            var (status, datareturn, messages) = await _service.ReadAsync(comunidadid);
            if (status == false)
            {
                return NotFound(messages.ToList());
            }
            else
            {
                return Ok(datareturn);
            }
        }
        //POST: Comunidad
        [HttpPost]
        public async Task<ActionResult> Add(ComunidadAddDto data)
        {
            var (status, datareturn, messages) = await _service.AddAsync(data);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }
        [HttpPut("{comunidadid}")]
        public async Task<ActionResult> Write(int comunidadid, ComunidadEditDto data)
        {
            var (status, datareturn, messages) = await _service.WriteAsync(comunidadid, data);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }
        [HttpDelete("{comunidadid}")]
        public async Task<ActionResult> Delete(int comunidadid)
        {
            var (status, datareturn, messages) = await _service.DeleteAsync(comunidadid);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }
    }
}
