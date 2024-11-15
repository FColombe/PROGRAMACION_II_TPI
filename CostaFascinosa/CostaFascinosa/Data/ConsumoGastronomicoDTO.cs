using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Data
{
    public class ConsumoGastronomicoDTO
    {
        public int idConsumo { get; set; }
        public int? IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total => Precio * Cantidad;
    }

}
