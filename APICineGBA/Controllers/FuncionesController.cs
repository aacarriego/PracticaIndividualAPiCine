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


        //GET: api/<ValuesController> query parameters optionally
        [HttpGet]
        [ProducesResponseType(typeof(FuncionDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 400)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 500)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 404)]
        public async Task<IActionResult> GetAll(string? fecha, string? titulo, int? genero)
        {
            var filtros = new BuscadorFunciones
            {
                Titulo = titulo,
                Fecha = fecha,
                GeneroId= genero
            };
            try
            {
                var result = await _service.ListarFunciones(filtros);
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


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FuncionDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 400)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 500)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 404)]
        public async Task<IActionResult> GetByFuncion(int id)
        {
            try
            {
                var result = await _service.GetFuncionById(id);
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

        //POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(typeof(FuncionDTO), 201)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 400)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 500)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 409)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 404)]
        public async Task<IActionResult> CrearFuncion(FuncionDTO request)
        {
            var funcion = new Funcion
            {
                PeliculaId = request.PeliculaId,
                SalaId = request.SalaId,
                Fecha = request.Fecha,

            };
            if (TimeSpan.TryParse(request.Horario, out var horario))
            {
                funcion.Horario = horario;
            }
            else
            {
                return BadRequest(new ErrorMessageHTTP
                {
                    message = "El formato de la hora es incorrecto",
                });
            }
            try
            {
                var result = await _service.CreateFuncion(funcion);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (InvalidDateFormatException e)
            {
                return BadRequest(new ErrorMessageHTTP
                {
                    message = e.Message,
                });
            }
            catch (InvalidTimeFormatException e)
            {
                return BadRequest(new ErrorMessageHTTP
                {
                    message = e.Message,
                });
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
                return Conflict(new ErrorMessageHTTP
                {
                    message = e.Message,
                });
            }

        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FuncionDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 400)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 500)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 409)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 404)]
        public async Task<IActionResult> EliminarFuncion(int id)
        {
            try
            {
                var result = await _service.DeleteFuncion(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ElementNotFoundException e)
            {
                return NotFound(new ErrorMessageHTTP
                {
                    message = e.Message,
                });
            }
            catch (InvalidOperationException e)
            {
                return Conflict(new ErrorMessageHTTP
                {
                    message = e.Message,
                });
            }
            catch (System.IO.InvalidDataException e)
            {
                return BadRequest(new ErrorMessageHTTP
                {
                    message = e.Message,
                });
            }
            catch (Exception e)
            {
                return Conflict(new ErrorMessageHTTP
                {
                    message = e.Message,
                });
            }

        }
        //GET api/<ValuesController>/5/tickets
        [HttpGet("{id}/tickets")]
        [ProducesResponseType(typeof(TicketDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 400)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 500)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 404)]
        public async Task<IActionResult> GetTicketsByFuncion(int id)
        {
            try
            {
                var result = await _service.GetTickectsByFuncionId(id);
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
        //POST api/<ValuesController>/5/tickets
        [HttpPost("{id}/tickets")]
        [ProducesResponseType(typeof(TicketDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 400)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 500)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 409)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 404)]
        public async Task<IActionResult> PostTicketsByFuncion(int id, TicketDTO request)
        {
            try
            {
                var result = await _service.CrearTicketEnFuncion(id, request);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ElementNotFoundException e)
            {
                return NotFound(new ErrorMessageHTTP
                {
                    message = e.Message,
                });
            }
            catch (InvalidOperationException e)
            {
                return Conflict(new ErrorMessageHTTP
                {
                    message = e.Message,
                });
            }
            catch (Exception e)
            {
                return Conflict(new ErrorMessageHTTP
                {
                    message = e.Message,
                });
            }

        }

    }

}

