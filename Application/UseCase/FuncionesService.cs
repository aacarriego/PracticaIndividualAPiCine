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

        public async Task<FuncionResponseDTO> CreateFuncion(Funcion request)
        {
            return await _command.InsertFuncion(request);
        }


        public async Task<FuncionResponseDTO> DeleteFuncion(int FuncionId)
        {
            return await _command.DeleteFuncion(FuncionId);
        }

        public async Task<List<Funcion>> GetAll()
        {
            return await _query.GetListFunciones();
        }

        public async Task<FuncionResponseDTO> GetById(int FuncionId)
        {
            var funcion = await _query.GetFuncion(FuncionId);

            return _mapper.Map<Funcion, FuncionResponseDTO>(funcion);
        }
    }
}
