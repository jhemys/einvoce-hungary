using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eInvoice.Hungary.Infrastructure;
using System.Net;
using eInvoice.Hungary.Domain.Model;
using eInvoice.Hungary.Infrastructure.WriteModel.Context;
using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Application.Invoices.CommandQuery.GetInvoices;
using MediatR;
using eInvoice.Hungary.Application.Invoices.CommandQuery.GetInvoice;

namespace eInvoice.Hungary.Api.Controllers
{
    [Route("api/hu/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly InvoiceContext _context;

        public InvoicesController(InvoiceContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
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
                if (!InvoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Invoices
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice", new { id = invoice.Id }, invoice);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Invoice>> DeleteInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return invoice;
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
