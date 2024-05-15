using Microsoft.AspNetCore.Mvc;
using Gestfin.Dtos;
using Gestfin.Services.Implementations;
using Gestfin.Services.Interfaces;

namespace Gestfin.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class ComunidadesController(IComunidadesService service) : ControllerBase
    {
        private readonly IComunidadesService _service = service;

        /// <summary>
        /// Obtiene una lista de comunidades.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/List")]
        public async Task<ActionResult<IEnumerable<ComunidadListDto>>> Index()
        {
            var result = await _service.ListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Obtiene una comunidad por su ID.
        /// </summary>
        /// <param name="comunidadid"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Agrega una nueva comunidad.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Modifica una comunidad.
        /// </summary>
        /// <param name="comunidadid"></param>
        /// <param name="data"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Elimina una comunidad.
        /// </summary>
        /// <param name="comunidadid"></param>
        /// <returns></returns>
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
