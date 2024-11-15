using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IResenasAmenity_repository
    {
        bool add(ResenasAmenity resenasAmenity);

        bool update(ResenasAmenity resenaAmenity);

        bool delete(ResenasAmenity resenaAmenity);

        List<ResenasAmenity> GetResenasAmenityByUsuario(int id);

        List<ResenasAmenity> GetResenasAmenityByPuntuacion(int puntuacion);
        List<ResenasAmenity> GetResenasAmenityByAmenity(int id);




    }
}
