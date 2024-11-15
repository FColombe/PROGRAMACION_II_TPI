using CostaFascinosa.Servicio.Interfaz;
using CostaFascinosa.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonaController : ControllerBase
    {
        private readonly IZona_service _serv;

        public ZonaController(IZona_service serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetZonas()
        {
            return  Ok(await _serv.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Zona zona)
        {
            try
            {
                if(zona == null)
                {
                    return BadRequest("Debe ingresar los datos de la zona.");
                }
                else
                {
                    return Ok(await _serv.Add(zona));
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno.");
            }
        }
    }
}
