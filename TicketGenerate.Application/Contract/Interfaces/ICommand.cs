using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketGenerate.Application.Contract.Interfaces
{
    public interface ICommand : IRequest
    {
        Guid CommandId { get; }
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid CommandId { get; }
    }
}
