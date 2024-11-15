using CostaFascinosa.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly COSTA_FASCINOSAContext _context;

    public AuthController(IAuthService authService, COSTA_FASCINOSAContext context)
    {
        _authService = authService ;
        _context = context;
    }
   
    [HttpPost("login")]
    public IActionResult Login([FromBody] usuarioToken userLogin)
    {
        var user = _context.Usuarios.FirstOrDefault(u => u.Nombre == userLogin.Username);
        //if (user == null || !VerifyPassword(userLogin.Password, user.Password))
        //{
        //    return Unauthorized("Credenciales incorrectas");
        //}

        var token = _authService.GenerarTokenJWT(user.Nombre, user.IdUsuario);
        return Ok(new { Token = token });
    }
    private bool VerifyPassword(string password, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, storedHash);
    }
}
