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

        public Task<Funcion> CreateFuncion(FuncionPostDTO request)
        {
            /// uso libreria automapping  
            var funcion = _mapper.Map<Funcion>(request);

            _command.InsertFuncion(funcion);
            return Task.FromResult(funcion);


        }


        //public async Task<ActionResult<FuncionDTO>> PostFuncion(FuncionPostDTO request)
        //{
        //    // Verifica si hay funciones existentes en la misma sala que se superponen en tiempo
        //    DateTime nuevaFuncionInicio = request.Horario; // Corrección aquí
        //    DateTime nuevaFuncionFin = nuevaFuncionInicio.AddMinutes(150); // 2 horas y 30 minutos

        //    bool superposicion = await _context.Funciones
        //        .AnyAsync(f =>
        //            f.SalaId == funcionPOST.SalaId &&
        //            f.Fecha.Date == funcionPOST.Fecha.Date && // Mismo día
        //            f.Horario <= nuevaFuncionFin && f.Horario.AddMinutes(150) >= nuevaFuncionInicio); // Superposición de horarios

        //    if (superposicion)
        //    {
        //        return BadRequest("La nueva función se superpone con otra función en la misma sala.");
        //    }

        //    var funcion = new Funcion
        //    {
        //        SalaId = funcionPOST.SalaId,
        //        Fecha = funcionPOST.Fecha,
        //        Horario = funcionPOST.Horario,
        //        PeliculaId = funcionPOST.PeliculaId
        //    };

        //    _context.Funciones.Add(funcion);
        //    await _context.SaveChangesAsync();

        //    // Devuelve la función creada
        //    var funcionDTO = new FuncionDTO
        //    {
        //        SalaId = funcion.SalaId,
        //        Fecha = funcion.Fecha,
        //        Horario = funcion.Horario,
        //        PeliculaId = funcion.PeliculaId
        //    };

        //    return CreatedAtAction("GetFuncion", new { id = funcion.FuncionId }, funcionDTO);
        //}

        public Task<Funcion> DeleteFuncion(int FuncionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Funcion>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Funcion> GetById(int FuncionId)
        {
            throw new NotImplementedException();
        }
    }
}
