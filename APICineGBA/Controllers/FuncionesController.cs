using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APICineGBA.Controllers
{
    [Route("api/v1/Funcion")]
    [ApiController]
    public class FuncionesController : ControllerBase
    {
        private readonly IFuncionesService _service;

        public FuncionesController(IFuncionesService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(DateTime? fecha , string? tituloPelicula , int? generoId )
        {
            var result = await _service.GetAll(fecha,  tituloPelicula  , generoId);

            return new JsonResult(result);

        }

        [HttpPost]

        public async Task<IActionResult> CreateFuncion(FuncionDTO request)
        {
            var funcion = new Funcion
            {
                PeliculaId = request.PeliculaId,
                Fecha = request.Fecha,
                SalaId = request.SalaId,
                //Horario = request.Horario
            };
            if (TimeSpan.TryParse(request.Horario, out TimeSpan horario))
            {
                funcion.Horario = horario;
            }
            else
            {
                return new JsonResult(new { error = "Horario invalido" });
            }   

            var result = await _service.CreateFuncion(funcion);

            return new JsonResult(result);

        }

      

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncion(int id)
        {
           var result = await _service.DeleteFuncion(id);

            return new JsonResult(result);
        }



    }

}

