

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
        private readonly IFuncionesQuery _query;
        private readonly IFuncionesCommand _command;

        public FuncionesService(IMapper mapper, IFuncionesQuery query, IFuncionesCommand command)
        {
            _mapper = mapper;
            _query = query;
            _command = command;
        }

        public void CrearFuncion(int PeliculaId, int SalaId, DateTime fecha, TimeSpan hora)
        {
            throw new NotImplementedException();
        }

        public Task<TicketNewDTOResponse> CrearTickeEnFuncion(int Id, TicketDTO ticket)
        {
            throw new NotImplementedException();
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
