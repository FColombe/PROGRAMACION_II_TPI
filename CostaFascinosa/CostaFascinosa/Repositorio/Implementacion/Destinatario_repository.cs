using CostaFascinosa.Data;
using CostaFascinosa.Repositorio.Interfaz;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostaFascinosa.Repositorio.Implementacion
{
    public class Destinatario_repository : IDestinatario_repository
    {
        private readonly COSTA_FASCINOSAContext _context;

        public Destinatario_repository(COSTA_FASCINOSAContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Destinatario destinatario)
        {
            _context.Add(destinatario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Destinatario>> GetDestinatarios()
        {
            return await _context.Destinatarios.ToListAsync();
        }
    }
}
