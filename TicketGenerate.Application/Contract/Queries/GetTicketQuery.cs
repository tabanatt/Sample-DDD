using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketGenerate.Application.Contract.Interfaces;
using TicketGenerate.Application.ViewModels;

namespace TicketGenerate.Application.Contract.Queries
{
    public class GetTicketQuery : IQuery<TicketDetailsDto>
    {

        public int Id { get; }

        public GetTicketQuery(int id)
        {
            Id = id;
        }

    }
}
