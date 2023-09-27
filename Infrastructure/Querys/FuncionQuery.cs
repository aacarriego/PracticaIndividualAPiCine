using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class FuncionesQuery : IFuncionesQuery
    {
        private readonly AppDbContext _context;
        public FuncionesQuery(AppDbContext context)
        {
            _context = context;
        }
        public Funcion GetFuncion(int FuncionId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Funcion>> GetListFunciones()
        {
            return await _context.Funciones.ToListAsync();
        }
    }
}
