using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IResenasActividade_repository
    {
        bool add(ResenasActividade resenaActividad);
        bool update(ResenasActividade resenaActividad);
        bool delete(ResenasActividade resenasActividade);

        ResenasActividade GetResenaActividadByPuntuacion(int puntuacion);

        ResenasActividade GetResenaActividadByActividad(int id);

        ResenasActividade GetResenaActividadByUsuario(int id);



    }
}
