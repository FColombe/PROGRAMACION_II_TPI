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
    public class ConsumosGastronomico_repository : IConsumosGastronomico_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public ConsumosGastronomico_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }



        public async Task<List<ConsumosGastronomico>> GetConsumosGastronomicosByUsuario(int id)
        {
            return await _context.ConsumosGastronomicos.Where(x => x.IdConsumoNavigation.IdUsuario == id).ToListAsync();
        }

        public async Task<List<ConsumoGastronomicoDTO>> GetTotalesConsumosGastronómicos(int id)
        {
            return await _context.ConsumosHabitaciones
                .Where(ch => ch.IdUsuario == id)
                .SelectMany(ch => ch.ConsumosGastronomicos)
                .Select(cg => new ConsumoGastronomicoDTO
                {
                    IdProducto = cg.IdProducto,
                    Cantidad = cg.Cantidad,
                    Precio = cg.Precio
                })
                .ToListAsync();
        }
    }
}
