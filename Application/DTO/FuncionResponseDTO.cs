using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class FuncionResponseDTO
    {
        public int FuncionId { get; set; }
       
        public DateTime Fecha { get; set; }

        public string Horario { get; set; }

        public SalaResponseDTO sala { get; set; }

        public PeliculaResponseDTO pelicula { get; set; }


    }

    public class SalaResponseDTO
    {
        public int SalaId { get; set; }
        public string Nombre{ get; set; }
        public int Capacidad { get; set; }

    }

    public class PeliculaResponseDTO
    {
        public int PeliculaId { get; set; }
        public string Titulo { get; set; }

        public string Poster { get; set; }

        public GeneroResponseDTO genero {get; set;}

    }
    
    public class GeneroResponseDTO
    {
        public int GeneroId { get; set; }
        public string Nombre { get; set;}
    }
}
