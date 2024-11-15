using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioGastronomicoController : ControllerBase
    {

        private readonly IServicioGastronomico_service _service;

        public ServicioGastronomicoController(IServicioGastronomico_service service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetServiciosGastronomicos());
        }
    }
}
