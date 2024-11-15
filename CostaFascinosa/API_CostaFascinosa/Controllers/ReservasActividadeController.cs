using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasActividadeController : ControllerBase
    {

        private readonly IReservasActividade_service _serv;

        public ReservasActividadeController(IReservasActividade_service serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serv.GetReservasActividades(GetUserId()));
        }

        [HttpGet("Diaria/{id}")]
        public async Task<IActionResult> GetDiaria(int id)
        {
            return Ok(await _serv.GetReservasActividadesDeHoy(id));
        }

        private int GetUserId()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            return int.Parse(userId);
        }

    }
}
