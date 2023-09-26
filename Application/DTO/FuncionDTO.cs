using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public  class FuncionDTO
    {
        public int FuncionId { get; set; }
        public int SalaId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Horario { get; set; }
        public int PeliculaId { get; set; }
    }
}
