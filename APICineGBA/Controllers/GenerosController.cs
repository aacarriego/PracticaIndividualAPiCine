using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICineGBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {

        private readonly IGeneroService _service;

        public GenerosController(IGeneroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listaDeGeneros= new List<GeneroDTO>();
        

            var result = await _service.GetAll();
            foreach (var genero in result)
            {
                var generoResult = new GeneroDTO();
                generoResult.GeneroId = genero.GeneroId;
                generoResult.Nombre = genero.Nombre;
                listaDeGeneros.Add(generoResult);
            }
            return new JsonResult(listaDeGeneros);
          
        }

        [HttpPost]

        public async Task<IActionResult> CreateGenero(GeneroDTO generoDTO) 
        {
            var result = await _service.CreateGenero(generoDTO);
            return new JsonResult(result);
        }


    }
}
