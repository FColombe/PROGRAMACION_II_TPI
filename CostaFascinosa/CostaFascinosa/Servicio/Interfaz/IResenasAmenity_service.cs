using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IResenasAmenity_service
    {
        List<ResenasAmenity> GetResenasAmenities();

        ResenasAmenity GetResenaAmenity(int id);

        bool add(ResenasAmenity resenasAmenity);

        bool delete(int id);

        bool update(ResenasAmenity resenaAmenity);
    }
}
