using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class TicketCreacionDTO
    {
        public List<TicketIdResponseDTO> Tickets { get; set; }
        public FuncionResponseDTO Funcion { get; set; }
        public string Usuario { get; set; }
    }
}
