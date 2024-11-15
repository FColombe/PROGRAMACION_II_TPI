using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class Usuario_Service : IUsuario_service
    {
        private readonly IUsuario_repository _repository;

        public Usuario_Service(IUsuario_repository repository)
        {
            _repository = repository;
        }

        public UserDTO? GetUsuario(int id)
        {
            return  _repository.GetUsuario(id);
        }

        public async Task<Usuario> GetUsername(string username)
        {
            return await _repository.GetUsuario(username);
        }

        public async Task<bool> UpdatePassword(int idUsuario, int contraseña)
        {
            return await _repository.UpdateUsuario(idUsuario, contraseña);
        }
    }
}
