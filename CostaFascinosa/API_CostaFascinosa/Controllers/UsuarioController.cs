using CostaFascinosa.Servicio.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API_CostaFascinosa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuario_service _serv;

        public UsuarioController(IUsuario_service serv)
        {
            _serv = serv;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            {
                try
                {
                        return Ok( _serv.GetUsuario(GetUserId()));   
                }
                catch (Exception)
                {
                    return StatusCode(500, "Error interno.");
                }
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] int contraseña)
        {
            try
            {
                if(IsValid(contraseña))
                {
                    return Ok(await _serv.UpdatePassword(GetUserId(), contraseña));
                }
                else
                {
                    return BadRequest("La contraseña solo debe tener 4 dígitos.");
                }
                
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }


        private bool IsValid(int contraseña)
        {
            var largo = contraseña.ToString().Length;
            if (largo > 4)
            {
                return false;
            }
            else
            {
                return true;    
            }
        }
        private int GetUserId()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            return int.Parse(userId);
        }
    }
}
