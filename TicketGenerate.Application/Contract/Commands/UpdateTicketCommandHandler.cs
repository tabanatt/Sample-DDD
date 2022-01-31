using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketGenerate.Application.Contract.Interfaces;
using TicketGenerate.Domain.AggregatesModel.TicketAggregate;

namespace TicketGenerate.Application.Contract.Commands
{
    public class UpdateTicketCommandHandler : ICommandHandler<UpdateTicketCommand>
    {
        private readonly ITicketRepository _ticketRepository;

        public UpdateTicketCommandHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Unit> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByIdAsync(request.TicketId);
            ticket._title = request.Title;
            ticket._description = request.Description;
            await _ticketRepository.Update(request.TicketId, ticket);
            return Unit.Value;
        }
    }
}
