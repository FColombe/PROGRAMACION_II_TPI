using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class Actividade_service : IActividade_service
    {

        private readonly IActividade_repository _repository;

        public Actividade_service(IActividade_repository repository)
        {
            _repository = repository;
        }

        public async Task<List<Actividade>> GetActividad(string nombre)
        {
            return await _repository.GetActividad(nombre);
        }

        public async Task<List<Actividade>> GetActividades()
        {
            return await _repository.GetActividades();
        }
    }
}
