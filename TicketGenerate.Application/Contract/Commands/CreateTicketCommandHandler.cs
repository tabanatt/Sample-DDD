using System;
using System.Threading;
using System.Threading.Tasks;
using TicketGenerate.Application.Contract.Interfaces;
using TicketGenerate.Domain.AggregatesModel.TicketAggregate;

namespace TicketGenerate.Application.Contract.Commands
{
    public class CreateTicketCommandHandler : ICommandHandler<CreateTicketCommand, Ticket>
    {
        private readonly ITicketRepository _ticketRepository;

        public CreateTicketCommandHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Ticket> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            //string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            //int id = Int32.Parse(userId);

            var user = new User { Id = 1, Username = "username", Password = "pass" };

            var entity = new Ticket { _title = request.Title, _description = request.Description, _creationDate = DateTime.Now, User = user };
            return await _ticketRepository.Insert(entity);
        }
    }
}
