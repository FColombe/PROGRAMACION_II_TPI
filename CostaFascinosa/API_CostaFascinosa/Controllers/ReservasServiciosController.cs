using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasServiciosController : ControllerBase
    {
        private readonly IReservasServicio_service _serv;
        public ReservasServiciosController(IReservasServicio_service service)
        {
            _serv = service;
        }
        //[HttpGet]

        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
        //        return Ok(await _serv.GetReservasServicios());
        //    }
        //    catch
        //    {
        //        return StatusCode(500, "Error interno");
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            try
            {

                return Ok(await _serv.GetReservasServicio(GetUserId()));
            }
            catch
            {
                return StatusCode(500, "Error interno");
            }
        }
        [HttpGet("GetDate")]

        public async Task<IActionResult> GetDate(int id)
        {
            try
            {

                return Ok(await _serv.GetReservasServicioDate(id));
            }
            catch
            {
                return StatusCode(500, "Error interno");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservasServicio reservaServicio)
        {
            reservaServicio.IdUsuario = GetUserId();
            try
            {
                if (reservaServicio.CantidadReservada <= 0)
                {
                    return StatusCode(400, "Todos los campos son necesarios");
                }
                return Ok(await _serv.add(reservaServicio));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            try
            {
                return Ok(await _serv.Delete(id));
            }
            catch (Exception)
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
