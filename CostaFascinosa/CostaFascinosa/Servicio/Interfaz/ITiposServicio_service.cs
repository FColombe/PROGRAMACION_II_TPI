using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface ITiposServicio_service
    {
        Task<List<TiposServicio>> GetTiposServicios();

        Task<bool> Add(TiposServicio tipoServicio);
    }
}
