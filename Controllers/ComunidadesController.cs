using Microsoft.AspNetCore.Mvc;
using Gestfin.Dtos;
using Gestfin.Services;

namespace Gestfin.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ComunidadesController(ComunidadesService service) : ControllerBase
    {
        private readonly ComunidadesService _service = service;

        // GET: Comunidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComunidadListDto>>> Index()
        {
            var result = await _service.ListAsync();
            return Ok(result);
        }
        // GET: Comunidades
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ComunidadReadWriteDto>>> GetById(int id)
        {
            var (status, datareturn, messages) = await _service.ReadAsync(id);
            if (status == false)
            {
                return NotFound(messages.ToList());
            }
            else
            {
                return Ok(datareturn);
            }
        }
        //POST: Comunidades
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
        [HttpPut("{id}")]
        public async Task<ActionResult> Write(int id, ComunidadReadWriteDto data)
        {
            var (status, datareturn, messages) = await _service.WriteAsync(id,data);
            if (status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var (status, datareturn, messages) = await _service.DeleteAsync(id);
            if(status == false)
            {
                return BadRequest(messages.ToList());
            }
            return Ok(datareturn);
        }
    }
}
