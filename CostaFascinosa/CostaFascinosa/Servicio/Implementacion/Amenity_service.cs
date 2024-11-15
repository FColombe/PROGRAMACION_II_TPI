using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Servicio.Implementacion
{
    public class Amenity_service : IAmenity_service
    {

        private readonly IAmenity_repository _repository;

        public Amenity_service(IAmenity_repository repository)
        {
            _repository = repository;
        }

        public async Task<List<Amenity>> GetAmenity(string nombre)
        {
            return await _repository.GetAmenity(nombre);
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            return await _repository.GetAmenities();
        }

        
    }
}
