using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class FuncionDeleteResponseDTO
    {
        public int FuncionId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
    }
}
