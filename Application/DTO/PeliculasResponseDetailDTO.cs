using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class PeliculasResponseDetailDTO
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string Trailer { get; set; }
        public string Poster { get; set; }
        public GeneroResponseDTO genero { get; set; }
        public List<FuncionDetailDTO> funciones { get; set; }
    }
}
