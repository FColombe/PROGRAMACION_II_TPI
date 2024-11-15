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
    public class ProductosGastronomico_repository : IProductosGastronomico_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public ProductosGastronomico_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public async Task<List<ProductosGastronomico>> GetProductosGastronomico()
        {
            return await _context.ProductosGastronomicos.ToListAsync();
        }
    }
}
