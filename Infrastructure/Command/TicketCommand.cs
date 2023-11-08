using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class TicketCommand : ITicketCommand
    {
        private readonly AppDbContext _context;
        public Task<TicketNewDTOResponse> CrearTicket(Ticket ticket)
        {
            _context.Add(ticket);
            _context.SaveChangesAsync();

            return Task.FromResult(new TicketNewDTOResponse
            {
            });
        }
    }
}
