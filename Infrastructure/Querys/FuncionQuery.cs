using Application.DTO;
using Application.Interfaces;
using Application.UseCase;
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

        public List<Funcion> GetAllFunciones()
        {
            throw new NotImplementedException();
        }

        public Task<FuncionResponseDTO> GetFuncionById(int FuncionId)
        {
            throw new NotImplementedException();
        }

        public Task<TicketIdResponseDTO> GetFuncionByTicketId(int FuncionId)
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionesByDia(DateTime dia)
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionesByPelicula(int PeliculaId)
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionesByPeliculaIDyFecha(int peliculaId, DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public Task<List<FuncionResponseDTO>> ListFunciones(BuscadorFunciones buscador)
        {
            throw new NotImplementedException();
        }
    }
}
      



                  




       

           
        
        
