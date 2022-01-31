using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketGenerate.Application.Contract.Interfaces;
using TicketGenerate.Application.ViewModels;
using TicketGenerate.Domain.AggregatesModel.TicketAggregate;

namespace TicketGenerate.Application.Contract.Queries
{
    public class GetTicketQueryHandler : IQueryHandler<GetTicketQuery, TicketDetailsDto>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketQueryHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }


        public async Task<TicketDetailsDto> Handle(GetTicketQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByIdAsync(request.Id);

            if(ticket == null)
            {
                return null;
            }

            var result = new TicketDetailsDto
            {
                FullName = ticket.User.FullName,
                PersianCreatedDate = ticket._creationDate,
                Title = ticket._title,
                Description = ticket._description
            };

            return result;
        }
    }
}
