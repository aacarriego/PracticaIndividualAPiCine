using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Command
{
    public class FuncionesCommand : IFuncionesCommand
    {
        private readonly AppDbContext _context;

       
        public FuncionesCommand(AppDbContext context)
        {
            _context = context;
            
        }

        public void CrearFuncion(Funcion funcion)
        {
            _context.Funciones.Add(funcion);
            _context.SaveChanges();
        }

        public  Task<FuncionResponseDTO> InsertFuncion(Funcion funcion)
        {

            _context.Funciones.Add(funcion);
            _context.SaveChanges();
            return Task.FromResult(new FuncionResponseDTO
            {

            });

        }

        public Task<FuncionDetailDTO> DeleteFuncion(int funcionId)
        {
            _context.Funciones.Remove(_context.Funciones.Find(funcionId));
            _context.SaveChanges();
            return Task.FromResult(new FuncionDetailDTO
            {

            }); 
            
        }
             
        public Task<FuncionResponseDTO> UpdateFuncion(int funcionId)
        {
            throw new NotImplementedException();
        }

    }
}
