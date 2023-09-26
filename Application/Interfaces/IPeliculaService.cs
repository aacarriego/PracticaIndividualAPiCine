using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPeliculaService
    {
        Task<Pelicula> CreatePelicula();

        Task<Pelicula> DeletePelicula();

        Task<List<Pelicula>> GetAll();

        Task<Pelicula> GetPeliculaById(int PeliculaId);


    }
}
