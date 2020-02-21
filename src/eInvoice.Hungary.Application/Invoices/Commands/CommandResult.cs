using MediatR;
using System.Collections.Generic;

namespace eInvoice.Hungary.Application.Invoices.Commands
{
    public class CommandResult : IRequest
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        private CommandResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = !string.IsNullOrEmpty(message) ? message : "Ne message provided.";
        }

        public static CommandResult Ok() => new CommandResult(true, string.Empty);
        public static CommandResult Ok(string message) => new CommandResult(true, message);
        public static CommandResult Fail(string message) => new CommandResult(false, message);
    }
}
