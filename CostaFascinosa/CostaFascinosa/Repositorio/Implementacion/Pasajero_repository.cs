using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Repositorio.Implementacion
{
    public class Pasajero_repository : IPasajero_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public Pasajero_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Pasajero pasajero)
        {
            _context.Pasajeros.Add(pasajero);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
