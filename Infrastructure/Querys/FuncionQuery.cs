using Application.DTO;
using Application.Interfaces;
using Application.UseCase;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Querys
{
    public class FuncionesQuery : IFuncionesQuery
    {
        private readonly AppDbContext _context;
        public FuncionesQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<Funcion> GetAllFunciones()
        {
          return  _context.Funciones.ToList();
        }

        public Task<FuncionResponseDTO> GetFuncionById(int FuncionId)
        {
            var funcion = _context.Funciones.Where(x => x.FuncionId == FuncionId).FirstOrDefaultAsync();
            var pelicula = _context.Peliculas.Where(x => x.PeliculaId == funcion.Result.PeliculaId).FirstOrDefaultAsync();
            var sala = _context.Salas.Where(x => x.SalaId == funcion.Result.SalaId).FirstOrDefaultAsync();
 
            return Task.FromResult(new FuncionResponseDTO
            {
                FuncionId = funcion.Result.FuncionId,
                pelicula = new PeliculaResponseDTO
                {  
                    PeliculaId = pelicula.Result.PeliculaId,
                    Titulo = pelicula.Result.Titulo,
                    Poster= pelicula.Result.Poster,
                    genero = new GeneroResponseDTO
                    {
                        GeneroId = pelicula.Result.Genero.GeneroId,
                        Nombre = pelicula.Result.Genero.Nombre
                    }

                },

                sala = new SalaResponseDTO
                {
                    SalaId = sala.Result.SalaId,
                    Nombre = sala.Result.Nombre,
                    Capacidad = sala.Result.Capacidad
                },
            });
        }

        public Task<List<FuncionResponseDTO>> ListFunciones(BuscadorFunciones buscador)
        {
            return Task.FromResult(_context.Funciones.Select(x => new FuncionResponseDTO
            {
                FuncionId = x.FuncionId,
                pelicula = new PeliculaResponseDTO
                {
                    PeliculaId = x.Pelicula.PeliculaId,
                    Titulo = x.Pelicula.Titulo,
                    Poster = x.Pelicula.Poster,
                    genero = new GeneroResponseDTO
                    {
                        GeneroId = x.Pelicula.Genero.GeneroId,
                        Nombre = x.Pelicula.Genero.Nombre
                    }
                },
                sala = new SalaResponseDTO
                {
                    SalaId = x.Sala.SalaId,
                    Nombre = x.Sala.Nombre,
                    Capacidad = x.Sala.Capacidad
                },
                Fecha = x.Fecha,
                Horario = x.Horario.ToString()
            }).ToList());
        }

        public List<Funcion> GetFuncionesByPeliculaIDyFecha(int peliculaId, DateTime fecha)
        {
            return _context.Funciones.Where(x => x.PeliculaId == peliculaId && x.Fecha == fecha).ToList();
        }
       
        public Task<TicketIdResponseDTO> GetFuncionByTicketId(int FuncionId)
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionesByDia(DateTime dia)
        {
            return _context.Funciones.Where(x => x.Fecha == dia).ToList();
          
        }

        public List<Funcion> GetFuncionesByPelicula(int PeliculaId)
        {
         return _context.Funciones.Where(x => x.PeliculaId == PeliculaId).ToList();
        }

        

        
        
    }
}
      



                  




       

           
        
        
