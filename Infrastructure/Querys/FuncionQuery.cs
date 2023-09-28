using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Infrastructure.Querys
{
    public class FuncionesQuery : IFuncionesQuery
    {
        private readonly AppDbContext _context;
        public FuncionesQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Funcion>> GetListFunciones()
        {
            return await _context.Funciones.ToListAsync();
        }

        public async Task<Funcion> GetFuncion(int FuncionId)
        {
            return await _context.Funciones.FindAsync(FuncionId);

        }
    }
}
      



                  




       

           
        
        
