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
    public class ServiciosGastronomico_repository : IServicioGastronomico_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public ServiciosGastronomico_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public async Task<List<ServiciosGastronomico>> GetServiciosGastronomicos()
        {
            return await _context.ServiciosGastronomicos
                .Include(e => e.IdCodVestimentaNavigation)
                .Include(e => e.IdDestinatarioNavigation)
                .Include(e => e.IdPreferenciaNavigation)
                .Include(e => e.IdTematicaNavigation)
                .Include(e => e.IdTipoServicioNavigation)
                .Include(e => e.IdZonaNavigation)
                .Include(e => e.IdTurnoAperturaNavigation)              
                .ToListAsync();
        }
    }
}
