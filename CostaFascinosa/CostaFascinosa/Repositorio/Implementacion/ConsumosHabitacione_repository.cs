using CostaFascinosa.Data;
using CostaFascinosa.Repositorio.Interfaz;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Repositorio.Implementacion
{
    public class ConsumosHabitacione_repository : IConsumosHabitacione_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public ConsumosHabitacione_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(ConsumosHabitacione consumo)
        {

            try
            {
                var listActividades = new List<Actividade>();
                var actividad = consumo.ReservasActividades;
                if (actividad != null && actividad.Count() > 0)
                {
                    foreach (var a in actividad)
                    {
                        var idAct = a.IdActividad;
                        var cupo = await _context.Actividades.FirstOrDefaultAsync(x => x.IdActividad == idAct);
                        if (cupo != null)
                        {
                            cupo.CupoMax = cupo.CupoMax - a.CantidadReservada;
                            listActividades.Add(cupo);
                        }
                    }

                    if(listActividades.Count() >0)
                    _context.UpdateRange(listActividades);
                    await _context.ConsumosHabitaciones.AddAsync(consumo);
                    var res = await _context.SaveChangesAsync() > 0;

                    return res;
                }
                var gastronomicos = consumo.ConsumosGastronomicos;

                if (gastronomicos != null && gastronomicos.Count() > 0)
                {

                    await _context.ConsumosHabitaciones.AddAsync(consumo);
                    var res = await _context.SaveChangesAsync() > 0;

                    return res;
                }

                return false;
            }


            catch (Exception e)
            {

                return false;
            }
        }

        public async Task<List<ConsumosHabitacioneDTO>> Get(int id)
        {
            var consumos = await _context.ConsumosHabitaciones
         .Where(u => u.IdUsuario == id)
         .Join(_context.ConsumosGastronomicos, 
             h => h.IdConsumo,
             g => g.IdConsumo,
             (h, g) => new { h, g })
         .Join(_context.ProductosGastronomicos, 
             combined => combined.g.IdProducto,
             p => p.IdProducto,
             (combined, p) => new
             {
                 combined.h.IdConsumo,
                 combined.h.Fecha,
                 combined.g.IdProducto,
                 combined.g.Cantidad,
                 combined.g.Precio,
                 p.Nombre
             })
         .ToListAsync();


            var consumosGastro = consumos
                .GroupBy(c => new { c.IdConsumo, c.Fecha })
                .Select(g => new ConsumosHabitacioneDTO
                {
                    IdConsumo = g.Key.IdConsumo,
                    Fecha = g.Key.Fecha,
                    ConsumoGastro = g.Select(c => new ConsumoGastronomicoDTO
                    {
                        IdProducto = c.IdProducto,
                        Cantidad = c.Cantidad,
                        Precio = c.Precio,
                        NombreProducto = c.Nombre
                    }).ToList()
                })
                .ToList();



            var consumosAct = await _context.ConsumosHabitaciones
                 .Where(u => u.IdUsuario == id)
                 .Join(_context.ReservasActividades,
                  h => h.IdConsumo,
                  r => r.IdConsumo,
                  (h, r) => new { h, r })
                 .Join(_context.Actividades,
                 combined => combined.r.IdActividad,
                 ac => ac.IdActividad,
                 (combined, ac) => new ConsumosHabitacioneDTO
                 {
                     IdConsumo = combined.h.IdConsumo,
                     Fecha = combined.h.Fecha,
                     IdActividad = combined.r.IdActividad,
                     Nombre = ac.Nombre,
                     FechaReserva = combined.r.FechaReservada,
                     CantidadAct = combined.r.CantidadReservada,
                     CostoUnitario = combined.r.CostoUnitario,
                 })
                 .ToListAsync();

            var consumosMap = consumosGastro
                .Concat(consumosAct)
                .GroupBy(c => c.IdConsumo)
                .Select(g => new ConsumosHabitacioneDTO
                {
                    IdConsumo = g.Key,
                    Fecha = g.FirstOrDefault()?.Fecha,
                    IdReserva = g.FirstOrDefault()?.IdReserva,
                    IdActividad = g.FirstOrDefault()?.IdActividad,
                    Nombre = g.FirstOrDefault()?.Nombre,
                    CantidadAct = g.FirstOrDefault()?.CantidadAct,
                    CostoUnitario = g.FirstOrDefault()?.CostoUnitario,
                    FechaReserva = g.FirstOrDefault()?.FechaReserva,
                    Servicio = g.FirstOrDefault()?.Servicio,
                    ConsumoGastro = g.SelectMany(c => c.ConsumoGastro ?? new List<ConsumoGastronomicoDTO>()).ToList()
                })
                .ToList();


            // dos variables con distintos dto que pueden entregar: uno si la lista está null, otro si no lo está
            //consumos.AddRange(consumosAct);
            //consumos.AddRange(consumosGastro);

            return consumosMap;
        }
        public async Task<decimal?> ObtenerTotalConsumosYReservas(int idUsuario)
        {
          
            var totalConsumosGastronomicos = await _context.ConsumosHabitaciones
                .Where(ch => ch.IdUsuario == idUsuario)
                .SelectMany(ch => ch.ConsumosGastronomicos)
                .SumAsync(cg => cg.Precio * cg.Cantidad);

           
            var totalReservasActividades = await _context.ConsumosHabitaciones
                .Where(ch => ch.IdUsuario == idUsuario)
                .SelectMany(ch => ch.ReservasActividades)
                .SumAsync(ra => ra.CostoUnitario * ra.CantidadReservada);

           
            return totalConsumosGastronomicos + totalReservasActividades;

        }


        public async Task<bool> Delete(int id)
        {
            try
            {
                var deleted = await _context.ConsumosHabitaciones.FindAsync(id);


                _context.ConsumosHabitaciones.Remove(deleted);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
