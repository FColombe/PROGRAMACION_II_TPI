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
    public class Zona_repository : IZona_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public Zona_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }
        public async Task<List<Zona>> GetAll()
        {
            return await _context.Zonas.ToListAsync();
        }

        public async Task<bool> Add(Zona zona)
        {
            _context.Zonas.Add(zona);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
