using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IReservasActividade_repository
    {

        Task<List<Reserva_ActividadeDTO>> GetReservasActividadesByUsuario(int id);
        Task<List<ReservasActividade>> GetReservasActividadesDelDia(int id);

    }
}
