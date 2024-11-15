using CostaFascinosa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface ICategoria_service
    {
        Task<List<Categoria>> GetCategorias();
        Task<bool> add(Categoria categoria);
    }
}
