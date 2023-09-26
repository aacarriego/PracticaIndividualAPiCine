using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class PeliculaService : IPeliculaService
    {

        private readonly IPeliculasCommand _command;

        private readonly IPeliculaQuery _query;

        public PeliculaService(IPeliculasCommand command, IPeliculaQuery query)
        {
            _command = command;
            _query = query;
        }

        

        
        ///
        public Task<Pelicula> CreatePelicula()
        {
            throw new NotImplementedException();
        }

        public Task<Pelicula> DeletePelicula()
        {
            throw new NotImplementedException();
        }

        public Task<List<Pelicula>> GetAll()
        {
            throw new NotImplementedException();
        } 

        public Task<Pelicula> GetPeliculaById(int PeliculaId)
        {
            throw new NotImplementedException();
        }
    }
}
