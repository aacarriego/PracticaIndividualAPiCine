using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class TicketNewDTOResponse
    {
        public string Usuario { get; set; }

        public LinkedList<TicketIdResponseDTO> Tickets { get; set; }

        public FuncionResponseDTO Funcion { get; set; }
    }
}
