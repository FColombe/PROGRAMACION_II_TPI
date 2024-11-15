using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class ProductosGastronomico_service : IProductosGastronomico_service
    {
        private readonly IProductosGastronomico_repository _repository;

        public ProductosGastronomico_service(IProductosGastronomico_repository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductosGastronomico>> GetProductosGastronomicos()
        {
            return await _repository.GetProductosGastronomico();
        }
    }
}
