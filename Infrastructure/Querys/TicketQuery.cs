using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;


namespace Infrastructure.Querys
{
    public class TicketQuery : ITicketQuery
    {
        private readonly AppDbContext _context;

        public TicketQuery(AppDbContext context)
        {
            _context = context;
        }
        public List<Ticket> GetAll()
        {
            return _context.Tickets.ToList();
        }

        public List<Ticket> GetByFuncionId(int id)
        {
            return _context.Tickets.Where(tk => tk.FuncionId == id).ToList();
        }

        public Pelicula? GetByPelculaId(int id)
        {
            return _context.Peliculas.Where(p => p.PeliculaId == id).FirstOrDefault();
        }
    }
}
