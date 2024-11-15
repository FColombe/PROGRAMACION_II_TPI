using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface ITurno_service
    {
        Task<List<Turno>> GetAll();
        Task<bool> Add(Turno turno);
    }
}
