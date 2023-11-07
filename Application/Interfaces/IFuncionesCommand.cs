using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFuncionesCommand
    {
        void CrearFuncion(Funcion funcion);
        Task<FuncionResponseDTO> InsertFuncion(Funcion funcion);
        Task<FuncionResponseDTO> UpdateFuncion(int funcionId);
        Task<FuncionDetailDTO> DeleteFuncion(int funcionId);
        
    }
}
