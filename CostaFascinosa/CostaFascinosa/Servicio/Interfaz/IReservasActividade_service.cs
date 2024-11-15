using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IReservasActividade_service
    {
        Task<List<Reserva_ActividadeDTO>> GetReservasActividades(int id);
        Task<List<ReservasActividade>> GetReservasActividadesDeHoy(int id);
    }
}
