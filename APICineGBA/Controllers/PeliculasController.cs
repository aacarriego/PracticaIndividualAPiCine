using Application.DTO;
using Application.ErrorHandler;
using Application.Interfaces;
using Application.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICineGBA.Controllers
{
    
    [Route("api/v1/Pelicula")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {

        // private readonly IServiceGetAll _service;

        private readonly IPeliculaService _service;

        public PeliculasController(IPeliculaService service)
        {
            _service = service;
        }

        // GET api/<PeliculaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PeliculasDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 404)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 400)]
        public async Task<IActionResult> GetPeliculaById(int id)
        {
            try
            {
                var result = await _service.GetPeliculaById(id);
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


        // PUT api/<PeliculaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PeliculaDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 404)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 400)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 500)]
        [ProducesResponseType(typeof(ErrorMessageHTTP), 409)]
        public async Task<IActionResult> UpdatePelicula(int id, PeliculaDTO request)
        {
            var PeliculaEditar = new PeliculaDTO
            {
                Titulo = request.Titulo,
                Poster = request.Poster,
                Trailer = request.Trailer,
                Sinopsis = request.Sinopsis,
                genero = request.genero
            };
            try
            {
                var result = await _service.ActualizarPelicula(id, PeliculaEditar);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ElementNotFoundException e)
            {
                return NotFound(new ErrorMessageHTTP
                {
                    message = e.Message,

                });
            }
            catch (ElementAlreadyExistException e)
            {
                return Conflict(new ErrorMessageHTTP
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

    }
}
