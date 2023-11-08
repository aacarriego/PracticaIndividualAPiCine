using Application.DTO;
using Application.ErrorHandler;
using Application.Interfaces;
using Application.UseCase;
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
        [ProducesResponseType(typeof(FuncionDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 400)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 500)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 404)]
        public async Task<IActionResult> GetAll(string? fecha , string? tituloPelicula , int? generoId )
        {
            var buscador= new BuscadorFunciones
            {
                Fecha = fecha,
                Titulo = tituloPelicula,
                Genero = generoId
            };

            try
            {
                var result = await _service.ListarFunciones(buscador);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ElementNotFoundException e)
            {
                return NotFound(new ErrorMessageHTTP
                {
                    message = e.Message,
                });

            }
            catch (Exception e)
            {
                return BadRequest(new ErrorMessageHTTP
                {
                    message = e.Message,
                });
            }  

        }

        [HttpPost]

        public async Task<IActionResult> CreateFuncion(FuncionDTO request)
        {
            var funcion = new Funcion
            {
                PeliculaId = request.PeliculaId,
                Fecha = request.Fecha,
                SalaId = request.SalaId,
                Horario = request.Horario
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

