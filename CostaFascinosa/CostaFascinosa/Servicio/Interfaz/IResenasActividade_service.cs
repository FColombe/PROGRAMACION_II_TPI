using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IResenasActividade_service
    {
        List<ResenasActividade> GetResenasActividades();

        ResenasActividade GetResenaActividad(int id);

        bool add(ResenasActividade resenaActividad);

        bool delete(int id);

        bool update(ResenasActividade resenaActividad);
    }
}
