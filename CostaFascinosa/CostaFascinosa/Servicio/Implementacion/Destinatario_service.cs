using CostaFascinosa.Data;
using CostaFascinosa.Repositorio.Interfaz;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class Destinatario_service : IDestinatario_service
    {
        private readonly IDestinatario_repository _repo;

        public Destinatario_service(IDestinatario_repository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Add(Destinatario destinatario)
        {
            return await _repo.Add(destinatario);
        }

        public async Task<List<Destinatario>> GetDestinatarios()
        {
            return await _repo.GetDestinatarios();
        }
    }
}
