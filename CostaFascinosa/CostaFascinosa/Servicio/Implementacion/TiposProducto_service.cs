using CostaFascinosa.Data;
using CostaFascinosa.Repositorio.Interfaz;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class TiposProducto_service : ITiposProducto_service
    {
        private readonly ITiposProducto_repository _repo;

        public TiposProducto_service(ITiposProducto_repository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Add(TiposProducto tipoProducto)
        {
            return await _repo.Add(tipoProducto);
        }

        public async Task<List<TiposProducto>> GetTiposProductos()
        {
            return await _repo.GetTiposProductos();
        }
    }
}
