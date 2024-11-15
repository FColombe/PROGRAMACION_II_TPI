using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IResenasServicio_repository
    {
      
        bool add(ResenasServicio resenaServicio);
        bool update(ResenasServicio resenasServicio);

        bool delete(ResenasServicio resenasServicio);

        List<ResenasServicio> GetResenasServicioByUsuario(int id);
        List<ResenasServicio> GetResenasServicioByPuntuacion(int puntuacion);
        List<ResenasServicio> GetResenasServicioByServicio(int id);

    }
}
