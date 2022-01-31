using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketGenerate.Domain.AggregatesModel.TicketAggregate;
using TicketGenerate.Domain.SeedWork;

namespace TicketGenerate.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        private readonly TicketContext _context;

        public TicketRepository(TicketContext context)
        {
            _context = context;
        }


        public async Task<Ticket> GetByIdAsync(int id)
        {
            var ticket = await _context.Tickets.Include(p => p.User).Where(p => p.Id == id).SingleOrDefaultAsync();
            if (ticket == null)
            {
                return null;
            }

            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync(int offset, int count)
        {
            return await _context.Tickets.OrderBy(p => p._creationDate).Skip(offset).Take(count).ToListAsync();
        }

        public async Task Remove(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task<Ticket> Insert(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        public async Task Update(int id, Ticket ticket)
        {
            _context.Tickets.Update(ticket);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
