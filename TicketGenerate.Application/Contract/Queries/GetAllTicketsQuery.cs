using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketGenerate.Application.Contract.Interfaces;
using TicketGenerate.Domain.AggregatesModel.TicketAggregate;

namespace TicketGenerate.Application.Contract.Queries
{
    public class GetAllTicketsQuery : IQuery<IEnumerable<Ticket>>
    {
        public int Offset { get; }
        public int Count { get; }

        public GetAllTicketsQuery(int offset, int count)
        {
            Offset = offset;
            Count = count;

        }
    }
}
