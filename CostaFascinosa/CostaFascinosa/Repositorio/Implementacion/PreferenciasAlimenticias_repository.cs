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
    public class PreferenciasAlimenticias_repository : IPreferenciaAlimenticia
    {
        private readonly COSTA_FASCINOSAContext _context;

        public PreferenciasAlimenticias_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(PreferenciasAlimenticia pref)
        {
            _context.PreferenciasAlimenticias.Add(pref);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<PreferenciasAlimenticia>> GetPrefAlimenticia()
        {
            return await _context.PreferenciasAlimenticias.ToListAsync();
        }
    }
}
