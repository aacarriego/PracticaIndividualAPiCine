using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class SalaService : ISalaService
    {
        private readonly ISalaQuery _salaQuery;

        public SalaService(ISalaQuery salaQuery)
        {
            _salaQuery = salaQuery;
        }

        public List<Sala> GetAll()
        {
            return _salaQuery.GetAll();
        }

        public Task<Sala> GetById(int id)
        {
          return _salaQuery.GetById(id);
        }
    }
}
