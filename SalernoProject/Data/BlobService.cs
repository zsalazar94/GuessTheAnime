using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace SalernoProject.Data
{
    public class BlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string AccountName = "animeopenings";
        private readonly string AccountKey = "YnaraorSwjoQftlPYcqtLFcT4fTWlx1+zWe+H3IdbQke2iSDy1rKrpyFumTPgdVApTfin8JNBQpL+AStn63nrA==";

        public BlobService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("myConnectionString");
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public string GenerateSasToken(string containerName, string blobName, int durationMinutes = 60)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            BlobSasBuilder sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = blobName,
                Resource = "b", // "b" for blob
                StartsOn = DateTimeOffset.UtcNow,
                ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(durationMinutes)
            };

            // Specify read permissions for the SAS
            sasBuilder.SetPermissions(BlobSasPermissions.Read);

            // Build the SAS token
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blobClient.Uri)
            {
                Sas = sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(AccountName, AccountKey))
            };

            return blobUriBuilder.ToUri().ToString();
        }

    }
}
