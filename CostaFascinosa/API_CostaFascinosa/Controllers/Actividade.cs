using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Actividade : ControllerBase
    {
        private readonly IActividade_service _serv;

        public Actividade(IActividade_service serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _serv.GetActividades());
        }

        [HttpGet("Buscar")]
        public async Task<IActionResult> Get(string nombre)
        {
            return Ok(await _serv.GetActividad(nombre));
        }
    }
}
