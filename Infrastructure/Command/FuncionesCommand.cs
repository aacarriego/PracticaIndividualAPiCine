using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Azure.Core;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Command
{
    public class FuncionesCommand : IFuncionesCommand
    {
        private readonly AppDbContext _context;

       
        public FuncionesCommand(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task<FuncionResponseDTO> DeleteFuncion(int funcionId)
        {

            List<Funcion> funciones = await _context.Funciones.ToListAsync();

            if (funciones == null && funciones.Count > 0) 
            {
                throw new Exception(" no existe ");
            }
            var funcion = await _context.Funciones.FindAsync(funcionId);    

            _context.Funciones.Remove(funcion);

            return new FuncionResponseDTO
            {
                FuncionId = funcion.FuncionId,
                Fecha = funcion.Fecha,
                Horario = funcion.Horario,
               
            };
        }

        public async Task<FuncionResponseDTO> InsertFuncion(Funcion request)
        {
            /// uso libreria automapping  
            /// 
          ;

            var funcion = new Funcion();
            funcion.Fecha = request.Fecha; 
            funcion.Horario = request.Horario;
            funcion.SalaId = request.SalaId;
            funcion.PeliculaId= request.PeliculaId;
            var pelicula= _context.Peliculas.Find(funcion.PeliculaId);
            funcion.Peliculas = pelicula;  
            var sala= _context.Salas.Find(funcion.SalaId);
            funcion.Salas = sala;
            funcion.Tickets = new List<Ticket>(sala.Capacidad);
            _context.Add(funcion);

            await _context.SaveChangesAsync();

            // var funcionResponse = _mapper.Map<funcion>(request);
            return new FuncionResponseDTO
            {
                FuncionId = funcion.FuncionId,

                Horario = funcion.Horario,
                Fecha = funcion.Fecha,
                pelicula = new PeliculaResponseDTO
                {
                    PeliculaId = funcion.PeliculaId,
                    Titulo = pelicula.Titulo,
                    Poster = pelicula.Poster,
                    genero = new GeneroResponseDTO
                    {
                        GeneroId = pelicula.GeneroId,
                        Nombre = _context.Generos.Find(pelicula.GeneroId).Nombre,
                    }
                },
                sala = new SalaResponseDTO
                {
                    SalaId = funcion.SalaId,
                    Nombre = _context.Salas.Find(funcion.SalaId).Nombre,
                    Capacidad = sala.Capacidad,
                }

            };
        }
    }
}
