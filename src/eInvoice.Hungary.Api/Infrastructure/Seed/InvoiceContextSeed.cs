using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;

namespace eInvoice.Hungary.Api.Infrastructure.Seed
{
    public class InvoiceContextSeed
    {
        public async Task SeedAsync(InvoiceContext context, IHostingEnvironment env, IOptions<InvoiceSettings> settings, ILogger<InvoiceContextSeed> logger)
        {
            var policy = CreatePolicy(logger, nameof(InvoiceContextSeed));

            await policy.Execute(async () =>
            {
                if (!context.Invoices.Any())
                {
                    context.Invoices.Add(new Model.Invoice
                    {
                        InvoiceNumber = "Test"
                    });

                    await context.SaveChangesAsync();
                }
            });
        }

        private Policy CreatePolicy(ILogger<InvoiceContextSeed> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetry(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix, exception.GetType().Name, exception.Message, retry, retries);
                    }
                );
        }
    }
}
