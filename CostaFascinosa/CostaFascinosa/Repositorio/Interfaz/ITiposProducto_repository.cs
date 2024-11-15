using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Repositorio.Interfaz
{
    public interface ITiposProducto_repository
    {
        Task<List<TiposProducto>> GetTiposProductos();

        Task<bool> Add(TiposProducto tipoProducto);
    }
}
