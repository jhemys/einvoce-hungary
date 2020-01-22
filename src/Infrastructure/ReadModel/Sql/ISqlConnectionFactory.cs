using System.Data;

namespace eInvoice.Hungary.Infrastructure.ReadModel.Sql
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
