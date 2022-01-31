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
    public class DeleteTicketCommandHandler : ICommandHandler<DeleteTicketCommand>
    {
        private readonly ITicketRepository _ticketRepository;

        public DeleteTicketCommandHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Unit> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            await _ticketRepository.Remove(request.TicketId);
            return Unit.Value;
        }
    }
}
