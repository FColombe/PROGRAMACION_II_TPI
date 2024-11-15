using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IReservasServicio_repository
    {


        Task<bool> add(ReservasServicio reservaServicio);

        Task<List<ReservasServicio>> GetReservasServicios();
        Task<List<ReservaServicioDTO>> GetReservasServicio(int id);
        Task<List<ReservasServicio>> GetReservasServicioDate(int id);
        Task<bool> Delete(int id);
    }
}
