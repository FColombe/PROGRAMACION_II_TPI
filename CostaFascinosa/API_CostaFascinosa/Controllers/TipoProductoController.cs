using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoController : ControllerBase
    {
        private readonly ITiposProducto_service _serv;

        public TipoProductoController(ITiposProducto_service serv)
        {
            _serv = serv;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serv.GetTiposProductos());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TiposProducto tipo)
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
