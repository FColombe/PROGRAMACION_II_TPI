using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class ResenasAmenity_repository : IResenasAmenity_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public ResenasAmenity_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public bool add(ResenasAmenity resenasAmenity)
        {
            throw new NotImplementedException();
        }

        public bool delete(ResenasAmenity resenaAmenity)
        {
            throw new NotImplementedException();
        }

        public List<ResenasAmenity> GetResenasAmenityByAmenity(int id)
        {
            throw new NotImplementedException();
        }

        public List<ResenasAmenity> GetResenasAmenityByPuntuacion(int puntuacion)
        {
            throw new NotImplementedException();
        }

        public List<ResenasAmenity> GetResenasAmenityByUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(ResenasAmenity resenaAmenity)
        {
            throw new NotImplementedException();
        }
    }
}
