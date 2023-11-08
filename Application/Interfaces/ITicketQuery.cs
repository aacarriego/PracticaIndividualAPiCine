using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITicketQuery
    {
        List<Ticket> GetAll();
        List<Ticket> GetByFuncionId(int id);
        Pelicula GetByPelculaId(int id);
    }
}
