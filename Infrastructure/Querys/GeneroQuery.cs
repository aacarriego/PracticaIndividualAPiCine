using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Querys
{
    public class GeneroQuery : IGeneroQuery
    {
        private readonly AppDbContext _context;

        public GeneroQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Genero> GetGenero(int GeneroId)
        {
            throw new NotImplementedException();
        }
        //perro

        public  List<Genero> GetListGenero()
        {
            return   _context.Generos.ToList();
        }
    }
}
