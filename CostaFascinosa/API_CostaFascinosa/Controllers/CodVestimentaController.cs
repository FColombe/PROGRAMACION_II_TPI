using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodVestimentaController : ControllerBase
    {
        private readonly ICodVestimenta_service _serv;

        public CodVestimentaController(ICodVestimenta_service serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetVestimenta()
        {
            return Ok(await _serv.GetCodigosVestimentas());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CodVestimenta vestimenta)
        {
            try
            {
                if(vestimenta == null)
                {
                    return BadRequest("Debe ingresar datos válidos.");
                }
                else
                {
                    return Ok(await _serv.add(vestimenta));
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }
    }
}
