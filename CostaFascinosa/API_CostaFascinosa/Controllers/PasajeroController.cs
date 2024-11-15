using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasajeroController : ControllerBase
    {
        private readonly IPasajero_service _serv;

        public PasajeroController(IPasajero_service serv)
        {
            _serv = serv;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pasajero pasajero) 
        {
            try
            {
                if(pasajero == null)
                {
                    return BadRequest("Debe ingresar los datos solicitados.");
                }
                else
                {
                    return Ok(await _serv.Add(pasajero));
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno.");
            }
        }
    }
}
