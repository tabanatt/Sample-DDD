using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketGenerate.Application.Contract.Interfaces;

namespace TicketGenerate.Application.Contract.Commands
{
    public class DeleteTicketCommand : ICommand
    {
        public Guid CommandId => throw new NotImplementedException();

        public int TicketId { get; }

        public DeleteTicketCommand(int id)
        {
            TicketId = id;
        }
    }
}
