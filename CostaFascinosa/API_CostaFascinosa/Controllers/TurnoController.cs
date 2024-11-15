using CostaFascinosa.Servicio.Interfaz;
using CostaFascinosa.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurno_service _serv;

        public TurnoController(ITurno_service serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _serv.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Turno turno)
        {
            try
            {
                if(turno == null)
                {
                    return BadRequest("Debe ingresar los datos solicitados");
                }
                else
                {
                    return Ok( await _serv.Add(turno));
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno.");
            }
        }
    }
}
