using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
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
            var listaDeFunciones = new List<FuncionDTO>();
            var result = await _service.GetAll();
            foreach (var funcion in result)
            {
                var funcionResult = new FuncionDTO();
                funcionResult.FuncionId = funcion.FuncionId;
                funcionResult.Fecha= funcion.Fecha;
                listaDeFunciones.Add(funcionResult);
            }
            return new JsonResult(listaDeFunciones);

        }

        [HttpPost]

        public async Task<IActionResult> CreateFuncion(FuncionRequestDTO request)
        {
            var funcion= new Funcion
            {
                PeliculaId= request.PeliculaId, 
                Fecha = request.Fecha,
                SalaId = request.SalaId,
                Horario = request.Horario
            };
         
             var result= await _service.CreateFuncion(funcion);

            return new JsonResult(result);

        }

    }
}
