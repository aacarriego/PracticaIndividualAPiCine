using Application.DTO;
using Application.UseCase;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFuncionesQuery
    {
               
        Task<List<FuncionResponseDTO>> ListFunciones( BuscadorFunciones buscador);
        
        Task<TicketIdResponseDTO> GetFuncionByTicketId(int FuncionId);

        Task<FuncionResponseDTO> GetFuncionById(int FuncionId);

        List<Funcion> GetAllFunciones();

        List<Funcion> GetFuncionesByPelicula(int PeliculaId);

        List<Funcion> GetFuncionesByDia(DateTime dia);

        List<Funcion> GetFuncionesByPeliculaIDyFecha(int peliculaId , DateTime fecha );

    }
}
