using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicioController : ControllerBase
    {
        private readonly ITiposServicio_service _serv;

        public TipoServicioController(ITiposServicio_service serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serv.GetTiposServicios());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TiposServicio tipo)
        {
            try
            {
                if (tipo == null)
                {
                    return BadRequest("Debe ingresar los datos solicitados.");
                }
                else
                {
                    return Ok(await _serv.Add(tipo));
                }

            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno.");
            }
        }
    }
}
