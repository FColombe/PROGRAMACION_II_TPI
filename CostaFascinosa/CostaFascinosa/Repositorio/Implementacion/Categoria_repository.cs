using CostaFascinosa.Data;
using CostaFascinosa.Servicio.Interfaz;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Repositorio.Implementacion
{
    public class Categoria_repository : ICategoria_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public Categoria_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }
        public async Task<List<Categoria>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }
        public async Task<bool> add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
