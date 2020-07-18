using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using eInvoice.Hungary.Infrastructure.WriteModel.Context;
using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Application.Invoices.Queries.GetInvoices;
using MediatR;
using eInvoice.Hungary.Application.IntegrationEvents;
using eInvoice.Hungary.Application.IntegrationEvents.Events;
using eInvoice.Hungary.Application.Invoices.Queries.GetInvoice;
using eInvoice.Hungary.Application.Invoices.Commands.AddInvoice;
using eInvoice.Hungary.Api.Models;
using eInvoice.Hungary.Application.Invoices.Commands;
using eInvoice.Hungary.Application.Invoices.Commands.DeleteInvoice;

namespace eInvoice.Hungary.Api.Controllers
{
    [Route("api/hu/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly SqlContext _context;
        private readonly IEventBus _eventBus;

        public InvoicesController(SqlContext context, IMediator mediator, IEventBus eventBus)
        {
            _context = context;
            _mediator = mediator;
            _eventBus = eventBus;
        }

        // GET: api/Invoices
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(InvoicesResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<InvoicesResult>> GetInvoices()
        {
            return await _mediator.Send(new GetInvoicesQuery());
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(InvoiceResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<InvoiceResult>> GetInvoice(int id)
        {
            var invoiceCommand = new GetInvoiceQuery(id);

            var invoiceResult = await _mediator.Send(invoiceCommand);

            if (invoiceResult == null)
                return NotFound();

            return invoiceResult;
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!InvoiceExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return NoContent();
        }

        // POST: api/Invoices
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CommandResult>> PostInvoice(InvoiceModel invoice)
        {
            var invoiceCommand = new AddInvoiceCommand(invoice.InvoiceNumber, invoice.InvoiceDate);

            var commandResult = await _mediator.Send(invoiceCommand);

            if (!commandResult.IsSuccess)
                return BadRequest(commandResult.Message);

            var @event = new InvoiceAcceptedEvent(invoice.InvoiceNumber);
            _eventBus.Publish(@event);

            return Ok(commandResult.Message);
        }

        // DELETE: api/Invoices/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Invoice>> DeleteInvoice(int id)
        //{
        //    var deleteInvoiceCommand = new DeleteInvoiceCommand(id);

        //    var commandResult = await _mediator.Send(deleteInvoiceCommand);

        //    if (!commandResult.IsSuccess)
        //        return BadRequest(commandResult.Message);

        //    return Ok(commandResult.Message);
        //}
    }
}
