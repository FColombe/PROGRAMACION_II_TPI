using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class Usuario_repository : IUsuario_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public Usuario_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public  UserDTO? GetUsuario(int id)
        {
            var usuario = _context.Usuarios
                                .Where(x => x.IdUsuario == id)
                                .Select(x => new UserDTO
                                {
                                    IdUsuario = x.IdUsuario,
                                    UserName = x.Nombre,
                                    Nombre = x.IdPasajeroNavigation.Nombre,
                                    Apellido = x.IdPasajeroNavigation.Apellido,
                                    NroHabitacion = x.IdPasajeroNavigation.NroHabitacion,
                                    ZonaHab = x.IdPasajeroNavigation.NroHabitacionNavigation.IdZonaNavigation.Descripcion,
                                    EstadoUser = x.IdPasajeroNavigation.IdEstadoNavigation.Descripcion,
                                    fech_abordo = x.IdPasajeroNavigation.FechaAbordo,
                                    fech_desbordo = x.IdPasajeroNavigation.FechaDesbordo

                                })
                                .FirstOrDefault(); 

            return usuario;
        }

        public async Task<Usuario> GetUsuario(string username)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.Nombre.Equals(username));
            return user;
        }

        public async Task<bool> UpdateUsuario(int idUsuario, int contraseña)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == idUsuario);
            if (user == null)
            {
                return false;
            }
            user.Contraseña = contraseña;
            return _context.SaveChanges() > 0;
        }
    }
}
