using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IProductosGastronomico_repository
    {

        Task<List<ProductosGastronomico>> GetProductosGastronomico();

    }
}
