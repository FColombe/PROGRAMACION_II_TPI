using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Repositorio.Implementacion
{
    public class Actividade_repository : IActividade_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public Actividade_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public async Task<List<Actividade>> GetActividad(string nombre)
        {
            return await _context.Actividades
                .Where(x => x.Nombre.StartsWith(nombre) || x.Descripcion.StartsWith(nombre))
                .Include(e => e.IdCategoriaNavigation)
                .Include(e => e.IdCodVestimentaNavigation)
                .Include(e => e.IdDestinatarioNavigation)
                .Include(e => e.IdCoordinadorNavigation)
                .Include(e => e.IdTurnoNavigation)
                .Include(e => e.IdZonaNavigation)
                .ToListAsync();
        }

        public async Task<List<Actividade>> GetActividades()
        {
            return await _context.Actividades
                            .Include(e => e.IdCategoriaNavigation)
                            .Include(e => e.IdCodVestimentaNavigation)
                            .Include(e => e.IdDestinatarioNavigation)
                            .Include(e => e.IdCoordinadorNavigation)
                            .Include(e => e.IdTurnoNavigation)
                            .Include(e => e.IdZonaNavigation)
                            .ToListAsync();
        }
    }
        
}
