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
    public interface IFuncionesService
    {
        void CrearFuncion(int PeliculaId, int SalaId, DateTime fecha, TimeSpan hora);

        Task<FuncionResponseDTO> CreateFuncion(Funcion request);

        Task<FuncionDetailDTO> DeleteFuncion(int FuncionId);

        Task<FuncionResponseDTO> UpdateFuncion(int FuncionId);

       
        Task<FuncionResponseDTO> GetFuncionById(int FuncionId);

        Task<TickectResponseCantidadDTO> GetTickectsByFuncionId(int FuncionId);
        Task<FuncionResponseDTO> ListarFunciones(BuscadorFunciones buscador);

        Task<TicketNewDTOResponse> CrearTickeEnFuncion(int Id, TicketDTO ticket);
        Task<TickectResponseCantidadDTO> TickectResponseCantidadDTO(int funcionId); 

        List<Funcion> GetAllFunciones();

        List<Funcion> GetFuncionesByPelicula(int PeliculaId);

        List<Funcion> GetFuncionesByDia(DateTime dia);

        List<Funcion> GetFuncionesByPeliculaIDyFecha(int peliculaId , DateTime fecha );
    }
}
