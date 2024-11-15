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
    public class CodVestimenta_repository : ICodVestimenta_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public CodVestimenta_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }
        public async Task<List<CodVestimenta>> GetCodigosVestimentas()
        {
            return await _context.CodVestimentas.ToListAsync();
        }
        public async Task<bool> add(CodVestimenta codVestimenta)
        {
            _context.CodVestimentas.Add(codVestimenta);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
