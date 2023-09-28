using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APICineGBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionesController : ControllerBase
    {
        private readonly IFuncionesService _service;

        public FuncionesController(IFuncionesService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();

            return new JsonResult(result);

        }

        [HttpPost]

        public async Task<IActionResult> CreateFuncion(FuncionRequestDTO request)
        {
            var funcion = new Funcion
            {
                PeliculaId = request.PeliculaId,
                Fecha = request.Fecha,
                SalaId = request.SalaId,
                Horario = request.Horario
            };

            var result = await _service.CreateFuncion(funcion);

            return new JsonResult(result);

        }

      

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncion(int FuncionId)
        {
           var result = await _service.DeleteFuncion(FuncionId);

            return new JsonResult(result);
        }



    }

}

