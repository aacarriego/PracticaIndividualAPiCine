using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITicketQuery
    {
        List<Ticket> GetAll();
        List<Ticket> GetByFuncion(int funcionId);
        Pelicula GetPelicula(int id);
    }
}
