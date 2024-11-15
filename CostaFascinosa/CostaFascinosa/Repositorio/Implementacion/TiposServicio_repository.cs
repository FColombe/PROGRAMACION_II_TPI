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
    public class TiposServicio_repository : ITiposServicio_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public TiposServicio_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(TiposServicio tipoServicio)
        {
           _context.TiposServicios.Add(tipoServicio);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TiposServicio>> GetTiposServicios()
        {
           return await _context.TiposServicios.ToListAsync();  
        }
    }
}
