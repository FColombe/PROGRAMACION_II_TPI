using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class Categoria_service : ICategoria_service
    {
        private readonly ICategoria_repository _repository;

        public Categoria_service(ICategoria_repository repository)
        {
            _repository = repository;
        }

        public async Task<bool> add(Categoria categoria)
        {
            return await _repository.add(categoria);
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            return await _repository.GetCategorias();
        }
    }
}
