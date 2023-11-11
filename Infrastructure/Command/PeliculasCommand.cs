using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{

    public class PeliculasCommand : IPeliculasCommand
    {
        private readonly AppDbContext _context;

        public PeliculasCommand(AppDbContext context)
        {
            _context = context;
        }
        public Task DeletePelicula(int peliculaId)
        {
            throw new NotImplementedException();
        }

        public async Task InsertPelicula(Pelicula pelicula)
        {
            _context.Add(pelicula);

            await _context.SaveChangesAsync();

        }
    }
}
