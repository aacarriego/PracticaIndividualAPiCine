using Application.DTO;
using Application.Interfaces;
using Application.UseCase;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{ 
   public class FuncionesService : IFuncionesService
    {
        private readonly IMapper _mapper;
        private readonly IFuncionesQuery _query;
        private readonly IFuncionesCommand _command;
        private readonly IGeneroQuery _generosQuery;
        private readonly ITicketCommand _ticketCommand;
        private readonly ITicketQuery _ticketQuery;


        public FuncionesService(IMapper mapper, IFuncionesQuery query, IFuncionesCommand command, ITicketCommand ticketCommand, ITicketQuery ticketQuery)
        {
            _mapper = mapper;
            _query = query;
            _command = command;
            _ticketCommand = ticketCommand;
            _ticketQuery = ticketQuery;
        }

        public async Task<FuncionResponseDTO> CreateFuncion(Funcion request)
        {
            return await _command.InsertFuncion(request);
        }


        public async Task<FuncionDeleteResponseDTO> DeleteFuncion(int FuncionId)
        {
            return await _command.DeleteFuncion(FuncionId);
        }

        public async Task<List<FuncionResponseDTO>> GetAll(DateTime? fecha, string? tituloPelicula, int? generoId)
        {

            return await _query.GetListFunciones(fecha, tituloPelicula, generoId);

        }

        public async Task<FuncionResponseDTO> GetById(int FuncionId)
        {
            var funcion = await _query.GetFuncion(FuncionId);

            return _mapper.Map<Funcion, FuncionResponseDTO>(funcion);
        }

        public async Task<TicketResponseDTO> CrearTicket(Ticket ticket)
        {
            return await _ticketCommand.CrearTicket(ticket);
        }   
    }
}
