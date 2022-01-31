using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketGenerate.Application.Contract.Interfaces;

namespace TicketGenerate.Application.Contract.Commands
{
    public class UpdateTicketCommand : ICommand
    {
        public Guid CommandId => throw new NotImplementedException();

        public int TicketId { get; set; }

        public string Title { get; }

        public string Description { get; }

        public UpdateTicketCommand(int ticketId, string title, string description)
        {
            TicketId = ticketId;
            Title = title;
            Description = description;
        }

    }
}
