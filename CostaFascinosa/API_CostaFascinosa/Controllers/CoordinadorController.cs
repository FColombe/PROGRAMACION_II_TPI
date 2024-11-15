using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CostaFascinosa.Servicio.Interfaz;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinadorController : ControllerBase
    {
        private readonly ICordinadore_service _serv;

        public CoordinadorController(ICordinadore_service serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serv.GetCoordinadores());  
        }
    }
}
