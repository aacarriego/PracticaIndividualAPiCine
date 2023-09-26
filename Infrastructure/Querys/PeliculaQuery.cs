using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class PeliculaQuery : IPeliculaQuery
    {
        private readonly AppDbContext _context;

        public PeliculaQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<Pelicula> GetListPelicula()
        {
            throw new NotImplementedException();
        }

        public Pelicula GetPelicula(int peliculaid)
        {
            var pelicula = _context.Peliculas
                .FirstOrDefault(p => p.PeliculaId == peliculaid);
            return pelicula;
        }
    }
}
