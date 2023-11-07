using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Command
{
    public class FuncionesCommand : IFuncionesCommand
    {
        private readonly AppDbContext _context;

       
        public FuncionesCommand(AppDbContext context)
        {
            _context = context;
            
        }

        public void CrearFuncion(Funcion funcion)
        {
            throw new NotImplementedException();
        }

        public async Task<FuncionDeleteResponseDTO> DeleteFuncion(int funcionId)
        {

            List<Funcion> funciones = await _context.Funciones.ToListAsync();

            if (funciones == null && funciones.Count > 0) 
            {
                throw new Exception(" no existe ");
            }
            var funcion = await _context.Funciones.FindAsync(funcionId);    

            _context.Funciones.Remove(funcion);

            await _context.SaveChangesAsync();

            return new FuncionDeleteResponseDTO
            {
                FuncionId = funcion.FuncionId,
                Fecha = funcion.Fecha,
                Horario = funcion.Horario,
               
            };
        }

        public async Task<FuncionResponseDTO> InsertFuncion(Funcion request)
        {
           
            var funcion = new Funcion();
            funcion.Fecha = request.Fecha; 
            funcion.Horario = request.Horario;
            funcion.SalaId = request.SalaId;
            funcion.PeliculaId= request.PeliculaId;
            var pelicula= _context.Peliculas.Find(funcion.PeliculaId);
            funcion.Pelicula = pelicula;  
            var sala= _context.Salas.Find(funcion.SalaId);
            funcion.Sala = sala;
            funcion.Tickets = new List<Ticket>(sala.Capacidad);
            _context.Add(funcion);

            await _context.SaveChangesAsync();

        
            return new FuncionResponseDTO
            {
                Horario= funcion.Horario,
                FuncionId = funcion.FuncionId,
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

        public Task<FuncionDetailDTO> UpdateFuncion(Funcion funcion)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionResponseDTO> UpdateFuncion(int funcionId)
        {
            throw new NotImplementedException();
        }

        Task<FuncionDetailDTO> IFuncionesCommand.DeleteFuncion(int funcionId)
        {
            throw new NotImplementedException();
        }
    }
}
