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
    public class SalaQuery : ISalaQuery
    {
        private readonly AppDbContext _context;

        public SalaQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<Sala> GetAll()
        {
            return _context.Salas.ToList();
        }

        public Sala? GetById(int id)
        {
            return _context.Salas.Where(s=> s.SalaId==id).FirstOrDefault();
        }
    }
}
