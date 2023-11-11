using Application.DTO;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IPeliculaQuery
    {

        List<Pelicula> GetAllPeliculas();
        Task<List<PeliculasDTO>> GetListaPeliculas();

        Task<PeliculasResponseDetailDTO> GetPeliculaById(int peliculaId);
        
        Pelicula  GetPelicula(int peliculaid);
            
        
    }
}
