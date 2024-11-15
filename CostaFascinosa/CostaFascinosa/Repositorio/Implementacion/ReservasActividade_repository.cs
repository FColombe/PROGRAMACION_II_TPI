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
    public class ReservasActividade_repository : IReservasActividade_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public ReservasActividade_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public async Task<List<Reserva_ActividadeDTO>> GetReservasActividadesByUsuario(int id)
        {
            var reserva = await _context.ReservasActividades
                .Where(x => x.IdConsumoNavigation.IdUsuario == id)
                .Select(x => new Reserva_ActividadeDTO
                {
                    idReservaAct = x.IdConsumoNavigation.IdConsumo,
                    idUsuario = x.IdConsumoNavigation.IdUsuarioNavigation.IdUsuario,
                    NombreActividad = x.IdActividadNavigation.Nombre,
                    FechaReserva = x.FechaReservada,
                    TurnoA = x.IdActividadNavigation.IdTurnoNavigation.FranjaHoraria,
                    ZonaA = x.IdActividadNavigation.IdZonaNavigation.Descripcion,
                    Piso = x.IdActividadNavigation.IdZonaNavigation.Piso,
                    CantidadReserva = x.CantidadReservada,
                    Costo = x.CostoUnitario
                })
                .ToListAsync();

            return reserva;
        }

        public async Task<List<ReservasActividade>> GetReservasActividadesDelDia(int id)
        {
            return await _context.ReservasActividades
                    .Where(x => x.IdConsumoNavigation.IdUsuario == id && x.FechaReservada == DateTime.Today)
                    .Include(e => e.IdActividadNavigation)
                    .ToListAsync();
        }
    }
}
