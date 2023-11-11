

using Application.DTO;
using Application.ErrorHandler;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using SharpCompress;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class FuncionesService : IFuncionesService
    {
        private readonly IMapper _mapper;
        private readonly IFuncionesQuery _FunQuery;
        private readonly IFuncionesCommand _FunCommand;
        private readonly ITicketCommand _ticketCommand;
        private readonly ITicketQuery _ticketQuery;
        private readonly ISalaQuery _salaQuery;
        private readonly IPeliculaQuery _peliculaQuery;
        private readonly IGeneroQuery _generoQuery;

        public FuncionesService(IMapper mapper, IFuncionesQuery query, IFuncionesCommand command, ITicketCommand ticketCommand, ITicketQuery ticketQuery, ISalaQuery salaQuery, IPeliculaQuery peliculaQuery, IGeneroQuery generoQuery)
        {
            _mapper = mapper;
            _FunQuery = query;
            _FunCommand = command;
            _ticketCommand = ticketCommand;
            _ticketQuery = ticketQuery;
            _salaQuery = salaQuery;
            _peliculaQuery = peliculaQuery;
            _generoQuery = generoQuery;
        }

        public void CrearFuncion(int PeliculaId, int SalaId, DateTime fecha, TimeSpan hora)
        {
            Funcion funcion = new Funcion
            {
                PeliculaId = PeliculaId,
                SalaId = SalaId,
                Fecha = fecha,
                Horario = hora
            };

        }

      

        public async Task<TicketNewDTOResponse> CrearTicketEnFuncion(int funcionId, TicketDTO ticketsPedidos)
        {
            var funcion = await _FunQuery.GetFuncionById(funcionId);
            var salaId = funcion.sala.SalaId;
            var peliculaId = funcion.pelicula.PeliculaId;
            var generoId = ( _peliculaQuery.GetPelicula(peliculaId)).GeneroId;
            var cantidadDisponibles = funcion.sala.Capacidad - _ticketQuery.GetAll().Count(x => x.FuncionId == funcionId);

            if (ticketsPedidos.Cantidad > cantidadDisponibles)
            {
                throw new Exception("No hay suficientes tickets disponibles");
            }

            var tickets = new List<TicketIdResponseDTO>();

            for (int i = 0; i < ticketsPedidos.Cantidad; i++)
            {
                if (cantidadDisponibles == 0)
                {
                    throw new Exception("No hay suficientes tickets disponibles en la función");
                }

                var nuevoTicket = new Ticket
                {
                    TicketId = Guid.NewGuid(),
                    FuncionId = funcionId,
                    Usuario = ticketsPedidos.Usuario,
                };

                tickets.Add(new TicketIdResponseDTO { TicketId = nuevoTicket.TicketId });
                await _ticketCommand.CrearTicket(nuevoTicket);
                cantidadDisponibles--;
            }

            var pelicula =  _peliculaQuery.GetPelicula(peliculaId);
            var sala = await _salaQuery.GetById(salaId);
            var genero = await _generoQuery.GetGenero(generoId);

            var funcionResponse = new FuncionResponseDTO
            {
                FuncionId = funcionId,
                pelicula = new PeliculaResponseDTO
                {
                    PeliculaId = peliculaId,
                    Titulo = pelicula.Titulo,
                    Poster = pelicula.Poster,
                    genero = new GeneroResponseDTO
                    {
                        GeneroId = generoId,
                        Nombre = genero.Nombre
                    }
                },
                sala = new SalaResponseDTO
                {
                    SalaId = salaId,
                    Nombre = sala.Nombre,
                    Capacidad = sala.Capacidad
                },
                Fecha = funcion.Fecha,
                Horario = funcion.Horario.ToString()
            };

            return new TicketNewDTOResponse
            {
                Tickets = tickets,
                Funcion = funcionResponse,
                Usuario = ticketsPedidos.Usuario
            };
        }

        

        public async Task<FuncionResponseDTO> CreateFuncion(Funcion request)
        {
            var listaFunciones =  _FunQuery.GetAllFunciones() ?? throw new Exception("No hay funciones");

            if (!DateTime.TryParse(request.Fecha.ToString(), out DateTime fecha) || !TimeSpan.TryParse(request.ToString(), out TimeSpan hora))
            {
                throw new InvalidFormatException("Formato de fecha u hora inválido");
            }

            var pelicula = _peliculaQuery.GetPelicula(request.PeliculaId) ?? throw new ElementNotFoundException("Película no encontrada");
            var sala = _salaQuery.GetById(request.SalaId) ?? throw new ElementNotFoundException("Sala no encontrada");
            var genero = _generoQuery.GetGenero(pelicula.GeneroId) ?? throw new ElementNotFoundException("Género no encontrado");

            var funcion = new Funcion
            {
                Fecha = request.Fecha,
                PeliculaId = request.PeliculaId,
                SalaId = request.SalaId,
                Horario = request.Horario,
                Tickets = new List<Ticket>(sala.Result.Capacidad)
            };

            var horarioProximo = request.Horario.Add(new TimeSpan(2, 30, 0));
            var horarioAnterior = request.Horario.Add(new TimeSpan(-2, 30, 0));

            if (listaFunciones.Any(f => f.Fecha.Date == funcion.Fecha.Date && f.Horario == funcion.Horario && f.SalaId == funcion.SalaId))
            {
                throw new ElementAlreadyExistException("Ya existe una función para ese día y horario en esa sala");
            }

            if (listaFunciones.Any(f => f.Horario <= horarioProximo && f.Horario >= horarioAnterior && f.SalaId == funcion.SalaId && f.Fecha.Date == funcion.Fecha.Date))
            {
                throw new ElementAlreadyExistException("No se puede crear una función para ese día y horario en esa sala, hay superposición horaria. Intente nuevamente");
            }

            var response = await _FunCommand.InsertFuncion(funcion);

            response.FuncionId = funcion.FuncionId;
            response.pelicula = new PeliculaResponseDTO
            {
                PeliculaId = pelicula.PeliculaId,
                Titulo = pelicula.Titulo,
                Poster = pelicula.Poster,
                genero = new GeneroResponseDTO
                {
                    GeneroId = genero.Result.GeneroId,
                    Nombre = genero.Result.Nombre
                }
            };

            response.sala = new SalaResponseDTO
            {
                SalaId = sala.Result.SalaId,
                Nombre = sala.Result.Nombre,
                Capacidad = sala.Result.Capacidad
            };

            response.Fecha = funcion.Fecha;
            response.Horario = funcion.Horario.ToString();

            return response;
        }

        public async Task<FuncionDetailDTO> DeleteFuncion(int funcionId)
{
    var funcion = _FunQuery.GetFuncionById(funcionId) ?? throw new ElementNotFoundException("Función no encontrada");

    if (TickectResponseCantidadDTO(funcionId).Result.Cantidad > 0)
    {
        throw new ElementAlreadyExistException("No se puede eliminar la función porque hay tickets vendidos");
    }

    var response = await _FunCommand.DeleteFuncion(funcionId);

    return new FuncionDetailDTO
    {
        FuncionId = funcion.Result.FuncionId,
        Fecha = funcion.Result.Fecha,
        Horario = funcion.Result.Horario.ToString()
    };
}


        public List<Funcion> GetAllFunciones()
        {
            throw new NotImplementedException();
        }

        public Task<FuncionResponseDTO> GetFuncionById(int FuncionId)
        {
            return _FunQuery.GetFuncionById(FuncionId) ?? throw new ElementNotFoundException("No hay funciones para ese id");
        }

        public List<Funcion> GetFuncionesByDia(DateTime dia)
        {
            return _FunQuery.GetFuncionesByDia(dia) ?? throw new ElementNotFoundException("No hay funciones para ese día");
        }

        public List<Funcion> GetFuncionesByPelicula(int PeliculaId)
        {
            return  _FunQuery.GetFuncionesByPelicula(PeliculaId) ?? throw new ElementNotFoundException("No hay funciones para esa película");
        }

        public List<Funcion> GetFuncionesByPeliculaIDyFecha(int peliculaId, DateTime fecha)
        {
            return _FunQuery.GetFuncionesByPeliculaIDyFecha(peliculaId, fecha) ?? throw new ElementNotFoundException("No hay funciones para esa película y fecha");
        }

        public async Task<TickectResponseCantidadDTO> GetTickectsByFuncionId(int funcionId)
        {
            var funcion = _FunQuery.GetFuncionById(funcionId) ?? throw new ElementNotFoundException("Función no encontrada");
            var sala = _salaQuery.GetById(funcion.Result.sala.SalaId) ?? throw new ElementNotFoundException("Sala no encontrada");

            var tickets = _ticketQuery.GetByFuncionId(funcionId);
            var ticketsVendidos = tickets.Count;
            var ticketsDisponibles = sala.Result.Capacidad - ticketsVendidos;

            return new TickectResponseCantidadDTO
            {
                Cantidad = ticketsDisponibles
            };
        }

        public Task<List<FuncionResponseDTO>> ListarFunciones(BuscadorFunciones buscador)
        {
            var funciones = _FunQuery.GetAllFunciones();

            if (buscador.GeneroId != null)
            {
                ValidarGenero(buscador.GeneroId);

                var peliculasFiltradas = _peliculaQuery.GetAllPeliculas().Where(p => p.GeneroId == buscador.GeneroId).ToList();
                funciones = funciones.Where(x => peliculasFiltradas.Any(p => p.PeliculaId == x.PeliculaId)).ToList();
            }

            if (!string.IsNullOrEmpty(buscador.Titulo))
            {
                ValidarTitulo(buscador.Titulo);
                funciones = funciones.Where(x => x.Pelicula.Titulo.Contains(buscador.Titulo)).ToList();
            }

            if (!string.IsNullOrEmpty(buscador.Fecha))
            {
                ValidarFecha(buscador.Fecha);
                funciones = funciones.Where(x => x.Fecha.ToString("yyyy-MM-dd") == buscador.Fecha).ToList();
            }

            return Task.FromResult(funciones.Select(MapFuncionToDTO).ToList());
        }

        private void ValidarGenero(int? generoId)
        {
            var genero = _generoQuery.GetGenero(generoId.Value);
            if (genero == null)
            {
                throw new ElementNotFoundException("No hay funciones para el género ingresado");
            }
        }

        private void ValidarTitulo(string titulo)
        {

            if (!_peliculaQuery.Equals(titulo)) 
            {
                throw new ElementNotFoundException("No hay funciones para el título ingresado");
            }
        }

        private void ValidarFecha(string fecha)
        {
            if (!_FunQuery.GetAllFunciones().Any(f => f.Fecha.ToString("yyyy-MM-dd") == fecha))
            {
                throw new ElementNotFoundException("No hay funciones para la fecha ingresada");
            }
        }

        private FuncionResponseDTO MapFuncionToDTO(Funcion funcion)
        {
            return new FuncionResponseDTO
            {
                FuncionId = funcion.FuncionId,
                pelicula = new PeliculaResponseDTO
                {
                    PeliculaId = funcion.PeliculaId,
                    Titulo = _peliculaQuery.GetPelicula(funcion.PeliculaId).Titulo,
                    Poster = _peliculaQuery.GetPelicula(funcion.PeliculaId).Poster,
                    genero = new GeneroResponseDTO
                    {
                        GeneroId = _generoQuery.GetGenero(funcion.Pelicula.GeneroId).Result.GeneroId,
                        Nombre = _generoQuery.GetGenero(funcion.Pelicula.GeneroId).Result.Nombre
                    }
                },
                sala = new SalaResponseDTO
                {
                    SalaId = funcion.SalaId,
                    Nombre = _salaQuery.GetById(funcion.SalaId).Result.Nombre,
                    Capacidad = _salaQuery.GetById(funcion.SalaId).Result.Capacidad,
                },
                Fecha = new DateTime(funcion.Fecha.Year, funcion.Fecha.Month, funcion.Fecha.Day).Date,
                Horario = funcion.Horario.ToString(),
            };
        }

        public Task<TickectResponseCantidadDTO> TickectResponseCantidadDTO(int funcionId)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionResponseDTO> UpdateFuncion(int FuncionId)
        {
            throw new NotImplementedException();
        }
    }
}
