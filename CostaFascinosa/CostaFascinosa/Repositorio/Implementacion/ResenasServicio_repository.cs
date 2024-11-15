using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class ResenasServicio_repository : IResenasServicio_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public ResenasServicio_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public bool add(ResenasServicio resenaServicio)
        {
            throw new NotImplementedException();
        }

        public bool delete(ResenasServicio resenasServicio)
        {
            throw new NotImplementedException();
        }

        public List<ResenasServicio> GetResenasServicioByPuntuacion(int puntuacion)
        {
            throw new NotImplementedException();
        }

        public List<ResenasServicio> GetResenasServicioByServicio(int id)
        {
            throw new NotImplementedException();
        }

        public List<ResenasServicio> GetResenasServicioByUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(ResenasServicio resenasServicio)
        {
            throw new NotImplementedException();
        }
    }
}
