using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketGenerate.Domain.SeedWork;

namespace TicketGenerate.Domain.AggregatesModel.TicketAggregate
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetAllAsync(int offset, int count);
        Task<Ticket> GetByIdAsync(int id);
        Task<Ticket> Insert(Ticket ticket);
        Task Remove(int id);
        Task Update(int id, Ticket ticket);
        //bool Exist(int id);
    }
}
