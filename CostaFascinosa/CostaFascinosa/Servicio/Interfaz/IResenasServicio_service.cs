using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IResenasServicio_service
    {
        List<ResenasServicio> GetResenasServicios();

        ResenasServicio GetResenaServicio(int id);

        bool add(ResenasServicio resenaServicio);

        bool delete(int id);

        bool update(ResenasServicio resenasServicio);
    }
}
