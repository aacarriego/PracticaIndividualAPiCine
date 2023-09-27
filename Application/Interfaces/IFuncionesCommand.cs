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
        Task<FuncionResponseDTO> InsertFuncion(Funcion funcion);
        Task<FuncionResponseDTO> DeleteFuncion(int funcionId);
    }
}
