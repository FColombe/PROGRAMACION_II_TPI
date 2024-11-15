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
    public class Amenity_repository : IAmenity_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public Amenity_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            return await _context.Amenities
                    .Include(e => e.IdCategoriaNavigation)
                    .Include(e => e.IdCodVestimentaNavigation)
                    .Include(e => e.IdTurnoNavigation)
                    .Include(e => e.IdZonaNavigation)
                    .ToListAsync();
        }



        public async Task<List<Amenity>> GetAmenity(string nombre)
        {
            return await _context.Amenities
                 .Where(x => x.Nombre.StartsWith(nombre))
                 .Include(e => e.IdCategoriaNavigation)
                 .Include(e => e.IdCodVestimentaNavigation)
                 .Include(e => e.IdTurnoNavigation)
                 .Include(e => e.IdZonaNavigation)
                 .ToListAsync();
        }

    }
}
