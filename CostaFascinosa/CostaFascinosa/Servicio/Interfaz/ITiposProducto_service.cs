using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface ITiposProducto_service
    {
        Task<List<TiposProducto>> GetTiposProductos();
        Task<bool> Add(TiposProducto tipoProducto);
    }
}
