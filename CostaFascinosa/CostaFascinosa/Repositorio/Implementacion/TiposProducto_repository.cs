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
    public class TiposProducto_repository : ITiposProducto_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public TiposProducto_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(TiposProducto tipoProducto)
        {
            _context.TiposProductos.Add(tipoProducto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TiposProducto>> GetTiposProductos()
        {
            return await _context.TiposProductos.ToListAsync();
        }
    }
}
