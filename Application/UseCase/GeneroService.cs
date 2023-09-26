using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class GeneroService : IGeneroService
    {

        private readonly IGenerosCommand _command;

        private readonly IGeneroQuery _query;

        public GeneroService(IGenerosCommand command, IGeneroQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<Genero> CreateGenero(GeneroDTO generoDTO)
        {
            var genero = new Genero
            {
                Nombre= generoDTO.Nombre,
            };

          await  _command.InsertGenero(genero);
            
            return genero;
        }

        public Task<Genero> DeleteGenero()
        {
            throw new NotImplementedException();
        }

        public Task<List<Genero>> GetAll()
        {
           return Task.FromResult(_query.GetListGenero());
        }

        public Task<Genero> GetGeneroById(int GeneroId)
        {
            throw new NotImplementedException();
        }
    }
}
