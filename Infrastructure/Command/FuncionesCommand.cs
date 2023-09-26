using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class FuncionesCommand : IFuncionesCommand
    {
        private readonly AppDbContext _context;
        public FuncionesCommand(AppDbContext context)
        {
            _context = context;
        }

        public Task DeleteFuncion(Funcion funcionId)
        {
            throw new NotImplementedException();
        }

        public async Task InsertFuncion(Funcion funcion)
        {
            _context.Add(funcion);

            await _context.SaveChangesAsync();

        }

       
    }
}
