using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface ICodVestimenta_service
    {
        Task<List<CodVestimenta>> GetCodigosVestimentas();

        Task<bool> add(CodVestimenta codVestimenta);
    }
}
