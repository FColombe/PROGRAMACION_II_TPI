using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IUsuario_repository
    {

        UserDTO? GetUsuario(int id);
        Task<Usuario> GetUsuario(string username);

        Task<bool> UpdateUsuario(int idUsuario, int contraseña);
        
    }



}
