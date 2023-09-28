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
        Task<FuncionResponseDTO> CreateFuncion(Funcion request);

        Task<List<FuncionResponseDTO>> GetAll(DateTime? fecha, string? tituloPelicula, int? generoId);

        Task<FuncionResponseDTO> GetById(int FuncionId);

        Task<FuncionDeleteResponseDTO> DeleteFuncion(int FuncionId);
    }
}
