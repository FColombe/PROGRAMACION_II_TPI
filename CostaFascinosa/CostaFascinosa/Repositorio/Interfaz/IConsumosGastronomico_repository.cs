using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IConsumosGastronomico_repository
    {
        Task<List<ConsumosGastronomico>> GetConsumosGastronomicosByUsuario(int id);
        Task<List<ConsumoGastronomicoDTO>> GetTotalesConsumosGastronómicos(int id);

    }
}
