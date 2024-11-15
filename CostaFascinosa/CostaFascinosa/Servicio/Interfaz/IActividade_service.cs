using CostaFascinosa.Data;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Interfaz
{
    public interface IActividade_service
    {
        Task<List<Actividade>> GetActividades();

        Task<List<Actividade>> GetActividad(string nombre);

    }
}
