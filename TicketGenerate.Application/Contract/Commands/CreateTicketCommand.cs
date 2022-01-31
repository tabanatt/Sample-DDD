using System;
using TicketGenerate.Application.Contract.Interfaces;
using TicketGenerate.Domain.AggregatesModel.TicketAggregate;

namespace TicketGenerate.Application.Contract.Commands
{
    public class CreateTicketCommand : ICommand<Ticket>
    {
        public Guid CommandId => throw new NotImplementedException();

        public string Title { get; }

        public string Description { get; }

        public CreateTicketCommand(string title, string description)
        {
            Title = title;
            Description = description;
        }

    }
}
