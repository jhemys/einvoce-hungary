using System.IO;
using System.Threading.Tasks;
using Firebase.Storage;
using eInvoice.Hungary.Application.Storage;

namespace eInvoice.Hungary.Infrastructure.Storage.Firebase
{
    public class FirebaseCloudStorage : IStorage
    {
        private readonly FirebaseStorage _firebaseStorage;

        public FirebaseCloudStorage(string connection) => _firebaseStorage = new FirebaseStorage(connection);
        public async Task DeleteFile(string fileName, string location)
        {
            await _firebaseStorage.Child(location).Child(fileName).DeleteAsync();
        }

        public async Task<string> GetDownloadLink(string fileName, string location)
        {
            return await _firebaseStorage.Child(location).Child(fileName).GetDownloadUrlAsync();
        }

        public async Task<string> UploadFile(Stream stream, string fileName, string location)
        {
            return await _firebaseStorage.Child(location).Child(fileName).PutAsync(stream);
        }
    }
}
