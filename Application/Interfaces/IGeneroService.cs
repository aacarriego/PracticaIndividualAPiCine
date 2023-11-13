using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public  interface IGeneroService
    {
        Task<Genero> CreateGenero(GeneroDTO generoDTO );

        Task<Genero> DeleteGenero();

        Task<List<GeneroDTO>> GetAll();

        Task<Genero> GetGeneroById(int GeneroId);
    }
}
