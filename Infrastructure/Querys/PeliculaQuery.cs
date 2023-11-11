using Application.DTO;
using Application.ErrorHandler;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class PeliculaQuery : IPeliculaQuery
    {
        private readonly AppDbContext _context;

        public PeliculaQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<Pelicula> GetAllPeliculas()
        {
            return _context.Peliculas.ToList();
        }

        public Task<List<PeliculasDTO>> GetListaPeliculas()
        {
            throw new NotImplementedException();
        }

        public Pelicula GetPelicula(int peliculaid)
        {
            return _context.Peliculas.Where(p => p.PeliculaId == peliculaid).FirstOrDefault();
        }

        public Task<PeliculasResponseDetailDTO> GetPeliculaById(int peliculaId)
        {
            var pelicula = _context.Peliculas.Where(x => x.PeliculaId == peliculaId).FirstOrDefault() ?? throw new ElementNotFoundException("Película no encontrada");
            var genero = _context.Generos.Where(x => x.GeneroId == pelicula.GeneroId).FirstOrDefault();
            var funciones = _context.Funciones.Where(x => x.PeliculaId == peliculaId).ToList();
            return Task.FromResult(new PeliculasResponseDetailDTO
            {
                PeliculaId = pelicula.PeliculaId,
                Titulo = pelicula.Titulo,
                Poster = pelicula.Poster,
                Trailer = pelicula.Trailer,
                Sinopsis = pelicula.Sinopsis,
                genero = new GeneroResponseDTO
                {
                    GeneroId = genero.GeneroId,
                    Nombre = genero.Nombre
                },
                funciones = funciones.Select(x => new FuncionDetailDTO
                {
                    FuncionId = x.FuncionId,
                    Fecha = x.Fecha,
                    Horario = x.Horario.ToString(),
                }).ToList()
            });

        }
    }
    
}
