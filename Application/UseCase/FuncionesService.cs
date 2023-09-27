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

        public Task<FuncionResponseDTO> CreateFuncion(Funcion request)
        {
          

            return  _command.InsertFuncion(request);
            


        }


        public Task<Funcion> DeleteFuncion(int FuncionId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Funcion>> GetAll()
        {
            return await _query.GetListFunciones();
        }

        public Task<Funcion> GetById(int FuncionId)
        {
            throw new NotImplementedException();
        }
    }
}
