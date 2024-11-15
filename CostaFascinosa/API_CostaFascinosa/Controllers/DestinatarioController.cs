using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinatarioController : ControllerBase
    {

        private readonly IDestinatario_service _serv;

        public DestinatarioController(IDestinatario_service serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serv.GetDestinatarios());  
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Destinatario dest)
        {
            try
            {
                if (dest == null)
                {
                    return BadRequest("Debe ingresar los datos solicitados");
                }
                else
                {
                    return Ok(await _serv.Add(dest));
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno.");
            }
        }
    }
}
