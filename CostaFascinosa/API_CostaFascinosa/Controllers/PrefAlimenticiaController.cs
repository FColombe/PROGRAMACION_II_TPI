using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrefAlimenticiaController : ControllerBase
    {
        private readonly IPreferenciaAlimenticia_service _serv;

        public PrefAlimenticiaController(IPreferenciaAlimenticia_service serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serv.GetPreferenciasAlimenticias());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PreferenciasAlimenticia pref)
        {
            try
            {
                if (pref == null)
                {
                    return BadRequest("Deb ingresar los datos solicitados");
                }
                else
                {
                    return Ok(await _serv.Add(pref));
                }

            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno.");
            }
        }
    }
}
