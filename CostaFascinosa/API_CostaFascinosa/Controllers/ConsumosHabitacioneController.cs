using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumosHabitacioneController : ControllerBase
    {

        private readonly IConsumosHabitacione_service _serv;
        private readonly IUsuario_repository _usuario_repository;

        public ConsumosHabitacioneController(IConsumosHabitacione_service serv, IUsuario_repository usuario_repository)
        {
            _serv = serv;
            _usuario_repository = usuario_repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serv.GetConsumosHabitaciones(GetUserId())); 
        }
        [HttpGet("Total")]
        public async Task<IActionResult> GetTotal()
        {
            return Ok(new {total = await _serv.ObtenerTotalConsumosYReservas(GetUserId()) });  
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConsumosHabitacione consumo)
        {
            try
            {

                if (consumo == null)
                {
                    
                    return BadRequest("Envíe todos los datos");
                }
                else
                {
                    consumo.IdUsuario = GetUserId();
                    consumo.NroHabitacion = _usuario_repository.GetUsuario(GetUserId()).NroHabitacion;
                    return Ok(await _serv.Add(consumo));
                }

            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _serv.Delete(id));
            }
            catch (Exception e)
            {

                return StatusCode(500, "Error interno");
            }

        }

        private int GetUserId()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            return int.Parse(userId);
        }
    }
}
