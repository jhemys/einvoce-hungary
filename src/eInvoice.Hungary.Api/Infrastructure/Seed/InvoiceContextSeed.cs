using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace eInvoice.Hungary.Api.Infrastructure.Seed
{
    public class InvoiceContextSeed
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            var context = (InvoiceContext)applicationBuilder.ApplicationServices.GetService(typeof(InvoiceContext));
            using (context)
            {
                context.Database.Migrate();

                if (!context.Invoices.Any())
                {
                    context.Invoices.Add(new Model.Invoice
                    {
                        Id = 1,
                        InvoiceNumber = "Test"
                    });

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
