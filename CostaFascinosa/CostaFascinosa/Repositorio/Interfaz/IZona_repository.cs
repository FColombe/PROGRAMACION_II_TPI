using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IZona_repository
    {
        Task<List<Zona>> GetAll();
        Task<bool> Add(Zona zona);
    }
}
