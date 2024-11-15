using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TematicaController : ControllerBase
    {
        private readonly ITematica_service _serv;

        public TematicaController(ITematica_service serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serv.GetTematicas());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tematica tema)
        {
            try
            {
                if(tema == null)
                {
                    return BadRequest("Debe ingresar los datos solicitados.");
                }
                else
                {
                    return Ok(await _serv.Add(tema));
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno.");
            }
        }
    }
}
