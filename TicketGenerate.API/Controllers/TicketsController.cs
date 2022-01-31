using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketGenerate.Application.Contract.Commands;
using TicketGenerate.Application.Contract.Queries;
using TicketGenerate.Application.ViewModels;
using TicketGenerate.Domain.AggregatesModel.TicketAggregate;

namespace TicketGenerate.API.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : Controller
    {
        private readonly IMediator _mediator;

        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDetailsDto>> GetTicket(int id)
        {
            var query = new GetTicketQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return result;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetAll(int offset, int count)
        {
            var query = new GetAllTicketsQuery(offset, count);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTicket(TicketInsertDto ticket)
        {
            var query = new CreateTicketCommand(ticket.Title, ticket.Description);
            var result = await _mediator.Send(query);

            return CreatedAtAction("GetTicket", new { id = result.Id }, result.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, TicketUpdateDto ticketUpdate)
        {
            var query = new UpdateTicketCommand(id, ticketUpdate.Title, ticketUpdate.Description);
            await _mediator.Send(query);

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var query = new DeleteTicketCommand(id);
            await _mediator.Send(query);

            return Ok();
        }

    }
}
