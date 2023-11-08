

using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<TicketNewDTOResponse> CrearTickeEnFuncion(int Id, TicketDTO ticketsPedidos)
        {
            List<TicketIdResponseDTO> tickets = new();
            var funcion = _FunQuery.GetFuncionById(Id);
            var sala = _salaQuery.GetById(funcion.Result.sala.SalaId);
            var pelicula = _peliculaQuery.GetPelicula(funcion.Result.pelicula.PeliculaId);
            var genero = _generoQuery.GetGenero(pelicula.GeneroId);
            var SoldTickets = _ticketQuery.GetAll().Where(x => x.FuncionId == Id).ToList();
            var cantidadDisponibles = sala.Capacidad - SoldTickets.Count();
            if (cantidadDisponibles < ticketsPedidos.Cantidad)
            {
                throw new Exception("No hay suficientes tickets disponibles");

            }
            for (int i = 0; i < ticketsPedidos.Cantidad; i++)
            {
                if (SoldTickets.Count == sala.Capacidad)
                {
                    throw new Exception("No hay suficientes tickets disponibles en la funcion");
                }

                var nuevoTicket = new Ticket
                {
                    TicketId = new Guid(),
                    FuncionId = funcion.Result.FuncionId,
                    Usuario = ticketsPedidos.Usuario,

                };
                tickets.Add(new TicketIdResponseDTO { ticketId = nuevoTicket.TicketId });
                var response = _ticketCommand.CrearTicket(nuevoTicket);

            }

            return Task.FromResult(new TicketNewDTOResponse
            {
                Tickets = tickets,
                Funcion = new FuncionResponseDTO
                {
                    FuncionId = funcion.Result.FuncionId,
                    pelicula = new PeliculaResponseDTO
                    {
                        PeliculaId = pelicula.PeliculaId,
                        Titulo = pelicula.Titulo,
                        Poster = pelicula.Poster,
                        genero = new GeneroResponseDTO
                        {
                            GeneroId = genero.GeneroId,
                            Nombre = genero.Nombre
                        }
                    },
                    sala = new SalaResponseDTO
                    {
                        SalaId = sala.SalaId,
                        Nombre = sala.Nombre,
                        Capacidad = sala.Capacidad
                    },
                    Fecha = funcion.Result.Fecha,
                    Horario = funcion.Result.Horario.ToString()
                },
                Usuario = ticketsPedidos.Usuario,


            });
        }

        public Task<FuncionResponseDTO> CreateFuncion(Funcion request)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionDetailDTO> DeleteFuncion(int FuncionId)
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetAllFunciones()
        {
            throw new NotImplementedException();
        }

        public Task<FuncionResponseDTO> GetFuncionById(int FuncionId)
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionesByDia(DateTime dia)
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionesByPelicula(int PeliculaId)
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionesByPeliculaIDyFecha(int peliculaId, DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public Task<TickectResponseCantidadDTO> GetTickectsByFuncionId(int FuncionId)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionResponseDTO> ListarFunciones(BuscadorFunciones buscador)
        {
            throw new NotImplementedException();
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
