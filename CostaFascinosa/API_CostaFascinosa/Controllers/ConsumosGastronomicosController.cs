using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumosGastronomicosController : ControllerBase
    {
        private readonly IConsumosGastronomico_service _serv;

        public ConsumosGastronomicosController(IConsumosGastronomico_service serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serv.GetConsumosGastroByUsuario(GetUserId()));
        }

        [HttpGet("TotalConsumo")]
        public async Task<IActionResult> GetTotales()
        {
            return Ok(await _serv.GetConsumosGastronomicosTotales(GetUserId()));
        }

        private int GetUserId()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            return int.Parse(userId);
        }
    }
}
