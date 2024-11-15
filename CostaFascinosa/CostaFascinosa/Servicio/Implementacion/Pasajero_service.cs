using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class Pasajero_service : IPasajero_service
    {
        private readonly IPasajero_repository _repo;

        public Pasajero_service(IPasajero_repository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Add(Pasajero pasajero)
        {
            return await _repo.Add(pasajero);
        }
    }
}
