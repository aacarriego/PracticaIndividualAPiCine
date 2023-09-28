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

        Task<List<Funcion>> GetAll();

        Task<FuncionResponseDTO> GetById(int FuncionId);

        Task<FuncionDeleteResponseDTO> DeleteFuncion(int FuncionId);
    }
}
