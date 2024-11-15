using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class ResenasActividade_repository : IResenasActividade_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public ResenasActividade_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public bool add(ResenasActividade resenaActividad)
        {
            throw new NotImplementedException();
        }

        public bool delete(ResenasActividade resenasActividade)
        {
            throw new NotImplementedException();
        }

        public ResenasActividade GetResenaActividadByActividad(int id)
        {
            throw new NotImplementedException();
        }

        public ResenasActividade GetResenaActividadByPuntuacion(int puntuacion)
        {
            throw new NotImplementedException();
        }

        public ResenasActividade GetResenaActividadByUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(ResenasActividade resenaActividad)
        {
            throw new NotImplementedException();
        }
    }
}
