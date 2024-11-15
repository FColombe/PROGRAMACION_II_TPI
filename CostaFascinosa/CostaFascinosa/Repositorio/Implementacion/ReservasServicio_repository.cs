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
    public class ReservasServicio_repository : IReservasServicio_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public ReservasServicio_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public async Task<bool> add(ReservasServicio reservaServicio)
        {
            var servElegido = reservaServicio.IdServicio;

            var servicio = await _context.ServiciosGastronomicos.FirstOrDefaultAsync(x => x.IdServicio == servElegido);

            servicio.CupoMax = servicio.CupoMax - reservaServicio.CantidadReservada;
            
            
            
            _context.ReservasServicio.Add(reservaServicio);

            return _context.SaveChanges() > 0;

        }


        public async Task<List<ReservaServicioDTO>> GetReservasServicio(int id)
        {
            return await _context.ReservasServicio.Where(r => r.IdUsuarioNavigation.IdUsuario == id)
                .Select(x => new ReservaServicioDTO
                {
                    idReservaGastro = x.IdReservaServ,
                    IdReservaServ = x.IdReservaServ,
                    IdUsuarioServ = x.IdUsuarioNavigation.IdUsuario,
                    NombreServ = x.IdServicioNavigation.Nombre,
                    Fecha = x.Fecha,
                    Cantidad = x.CantidadReservada
                })
                .ToListAsync();
        }

        public async Task<List<ReservasServicio>> GetReservasServicioDate(int id)
        {
            return await _context.ReservasServicio.Where(r => r.IdUsuario == id && r.Fecha.Value.Date == DateTime.Today.Date)
                .Include(e => e.IdServicioNavigation)
                .Include(e => e.IdUsuarioNavigation.IdUsuario)
               .ToListAsync();
        }

        public async Task<List<ReservasServicio>> GetReservasServicios()
        {
            return await _context.ReservasServicio.ToListAsync();
        }

        public async Task<bool> Delete(int id)
        {

            try
            {
                var deleted = await _context.ReservasServicio.FirstOrDefaultAsync(x => x.IdReservaServ == id);

                if(deleted != null)
                {
                    _context.ReservasServicio.Remove(deleted);
                    _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                return false;
            }
            
        
        
        }
    }
}
