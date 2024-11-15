using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosGastronomicoController : ControllerBase
    {
        private readonly IProductosGastronomico_service _serv;

        public ProductosGastronomicoController(IProductosGastronomico_service serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serv.GetProductosGastronomicos());
        }
    }
}
