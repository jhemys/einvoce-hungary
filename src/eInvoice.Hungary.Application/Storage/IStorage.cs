using System.IO;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Application.Storage
{
    public interface IStorage
    {
        public Task<string> UploadFile(Stream stream, string fileName, string location);
        public Task<string> GetDownloadLink(string fileName, string location);
        public Task DeleteFile(string fileName, string location);
    }
}
