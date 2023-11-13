using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.DTO;

namespace Infrastructure.Querys
{
    public class GeneroQuery : IGeneroQuery
    {
        private readonly AppDbContext _context;

        public GeneroQuery(AppDbContext context)
        {
            _context = context;
        }

        public Genero GetGenero(int GeneroId)
        {
             var genero = _context.Generos.Where(g => g.GeneroId == GeneroId).FirstOrDefault();
            return genero;
        }
       
        public async Task<List<GeneroDTO>> GetListGenero()
        {
            return _context.Generos.Select(g => new GeneroDTO
            {
                GeneroId = g.GeneroId,
                Nombre = g.Nombre
            }).ToList();       

        }
    }
}
