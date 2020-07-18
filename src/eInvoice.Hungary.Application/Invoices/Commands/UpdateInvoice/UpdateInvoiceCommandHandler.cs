using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Application.Invoices.Commands.UpdateInvoice
{
    class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, CommandResult>
    {
        public Task<CommandResult> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
