using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IPreferenciaAlimenticia_service
    {
        Task<List<PreferenciasAlimenticia>> GetPreferenciasAlimenticias();
        Task<bool> Add(PreferenciasAlimenticia pref);
    }
}
