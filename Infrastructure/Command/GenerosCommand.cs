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
    public class GenerosCommand : IGenerosCommand
    {
        private readonly AppDbContext _context;

        public GenerosCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertGenero(Genero genero)
        {
                _context.Add(genero);

                await _context.SaveChangesAsync();
         }

        public Task RemoveGenero(int GeneroId)
        {
            throw new NotImplementedException();
        }
    }
}
