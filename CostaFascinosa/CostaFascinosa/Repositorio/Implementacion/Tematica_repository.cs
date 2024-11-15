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
    public class Tematica_repository : ITematica_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public Tematica_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Tematica tematica)
        {
            _context.Add(tematica);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Tematica>> GetTematicas()
        {
            return await _context.Tematicas.ToListAsync();
        }
    }
}
