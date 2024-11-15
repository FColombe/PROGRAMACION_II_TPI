using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IConsumosGastronomico_service
    {
        Task<List<ConsumoGastronomicoDTO>> GetConsumosGastronomicosTotales(int id);
        Task<List<ConsumosGastronomico>> GetConsumosGastroByUsuario(int id);    

    }
}
