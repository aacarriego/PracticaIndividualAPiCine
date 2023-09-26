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
        Task<Funcion> CreateFuncion(FuncionPostDTO request);

        Task<List<Funcion>> GetAll();

        Task<Funcion> GetById(int FuncionId);

        Task<Funcion> DeleteFuncion(int FuncionId);
    }
}
