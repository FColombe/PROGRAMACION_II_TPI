using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IServicioGastronomico_service
    {
        Task<List<ServiciosGastronomico>> GetServiciosGastronomicos();

    }
}
