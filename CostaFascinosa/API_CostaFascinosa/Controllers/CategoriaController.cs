using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CostaFascinosa.Data;
using Microsoft.AspNetCore.Authorization;


namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria_service _serv;

        public CategoriaController(ICategoria_service serv)
        {
            _serv = serv;
        }


        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serv.GetCategorias());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria cat)
        {
            try
            {
                if(cat == null)
                {
                    return BadRequest("Debe enviar datos válidos.");
                }
                else
                {
                    return Ok(await _serv.add(cat));
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }
    }
}
