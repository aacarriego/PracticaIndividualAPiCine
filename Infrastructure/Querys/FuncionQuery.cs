using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Infrastructure.Querys
{
    public class FuncionesQuery : IFuncionesQuery
    {
        private readonly AppDbContext _context;
        public FuncionesQuery(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<List<FuncionResponseDTO>> GetListFunciones()
        //{
        //    var funciones = await _context.Funciones
        //        .Include(f => f.Pelicula)
        //            .ThenInclude(p => p.Genero)
        //        .Include(f => f.Sala)
        //        .ToListAsync();

        //    var funcionesDto = funciones.Select(funcion => new FuncionResponseDTO
        //    {
        //        FuncionId = funcion.FuncionId,
        //        Fecha = funcion.Fecha,
        //        Horario = funcion.Horario,
        //        pelicula = new PeliculaResponseDTO
        //        {
        //            PeliculaId = funcion.PeliculaId,
        //            Titulo = funcion.Pelicula.Titulo,
        //            Poster = funcion.Pelicula.Poster,
        //            genero = new GeneroResponseDTO
        //            {
        //                GeneroId = funcion.Pelicula.Genero.GeneroId,
        //                Nombre = funcion.Pelicula.Genero.Nombre,
        //            }
        //        },
        //        sala = new SalaResponseDTO
        //        {
        //            SalaId = funcion.SalaId,
        //            Nombre = funcion.Sala.Nombre,
        //            Capacidad = funcion.Sala.Capacidad,
        //        }
        //    });

        //    return funcionesDto.ToList();
        //}


        public async Task<List<FuncionResponseDTO>> GetListFunciones(DateTime? fecha, string? tituloPelicula, int? generoId)
        {
            var query = _context.Funciones
                .Include(f => f.Pelicula)
                    .ThenInclude(p => p.Genero)
                .Include(f => f.Sala)
                .AsQueryable(); // Convierte la consulta en una IQueryable para agregar condiciones de filtro dinámicamente

            // Aplica los filtros según los parámetros proporcionados
            if (fecha.HasValue)
            {
                query = query.Where(funcion => funcion.Fecha.Date == fecha.Value.Date);
            }

            if (!string.IsNullOrEmpty(tituloPelicula))
            {
                query = query.Where(funcion => funcion.Pelicula.Titulo.Contains(tituloPelicula));
            }

            if (generoId.HasValue)
            {
                query = query.Where(funcion => funcion.Pelicula.GeneroId == generoId.Value);
            }

            var funciones = await query.ToListAsync();

            var funcionesDto = funciones.Select(funcion => new FuncionResponseDTO
            {
                FuncionId = funcion.FuncionId,
                Fecha = funcion.Fecha,
                Horario = funcion.Horario,
                pelicula = new PeliculaResponseDTO
                {
                    PeliculaId = funcion.PeliculaId,
                    Titulo = funcion.Pelicula.Titulo,
                    Poster = funcion.Pelicula.Poster,
                    genero = new GeneroResponseDTO
                    {
                        GeneroId = funcion.Pelicula.Genero.GeneroId,
                        Nombre = funcion.Pelicula.Genero.Nombre,
                    }
                },
                sala = new SalaResponseDTO
                {
                    SalaId = funcion.SalaId,
                    Nombre = funcion.Sala.Nombre,
                    Capacidad = funcion.Sala.Capacidad,
                }
            });

            return funcionesDto.ToList();
        }


        public async Task<Funcion> GetFuncion(int FuncionId)
        {
            return await _context.Funciones.FindAsync(FuncionId);

        }
    }
}
      



                  




       

           
        
        
