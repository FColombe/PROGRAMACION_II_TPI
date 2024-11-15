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
    public class Turno_repository : ITurno_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public Turno_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }
        public async Task<List<Turno>> GetAll()
        {
           return await _context.Turnos.ToListAsync();
        }
       

        public async Task<bool> Add(Turno turno)
        {
            _context.Turnos.Add(turno);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
