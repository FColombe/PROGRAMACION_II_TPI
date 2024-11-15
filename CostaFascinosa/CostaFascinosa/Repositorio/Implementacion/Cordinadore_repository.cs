using CostaFascinosa.Data;
using CostaFascinosa.Repositorio.Interfaz;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Repositorio.Implementacion
{
    public class Cordinadore_repository : ICordinadore_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public Cordinadore_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }
        public async Task<List<Coordinadore>> GetCoordinadores()
        {
            return await _context.Coordinadores.ToListAsync();
        }
    }
}
