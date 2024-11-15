using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IUsuario_service
    {
       UserDTO? GetUsuario(int id);
       Task<Usuario> GetUsername(string username);
       Task<bool> UpdatePassword(int idUsuario, int contraseña);
    }
}
