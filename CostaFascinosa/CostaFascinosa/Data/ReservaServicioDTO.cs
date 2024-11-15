using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Data
{
    public class ReservaServicioDTO
    {
        public int idReservaGastro {  get; set; }
        public int? IdReservaServ { get; set; }
        public int? IdUsuarioServ { get; set; }
        public string? NombreServ { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Cantidad { get; set; }

    }
}
