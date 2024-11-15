using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Amenities : ControllerBase
    {

        private readonly IAmenity_service _service;

        public Amenities(IAmenity_service service
            )
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAmenities());
        }

        [HttpGet("Buscar")]
        public async Task<IActionResult> GetAmeniti(string nombre)
        {
            return Ok(await _service.GetAmenity(nombre));
        }
    }
}
