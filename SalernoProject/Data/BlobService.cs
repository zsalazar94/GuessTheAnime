using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace SalernoProject.Data
{
    public class BlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        readonly string? connectionString;
        readonly string? accountName;
        readonly string? accountKey;
        readonly string? containerName;
        public BlobService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("storageConnectionString");
            accountName = configuration.GetConnectionString("storageAccountName");
            accountKey = configuration.GetConnectionString("storageAccountKey");
            containerName = configuration.GetConnectionString("containerName");
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public string GenerateSasToken(string blobPath, int durationMinutes = 60)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobPath);

            BlobSasBuilder sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                BlobName = blobPath,
                Resource = "b", // "b" for blob
                StartsOn = DateTimeOffset.UtcNow,
                ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(durationMinutes)
            };

            // Specify read permissions for the SAS
            sasBuilder.SetPermissions(BlobSasPermissions.Read);

            // Build the SAS token
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blobClient.Uri)
            {
                Sas = sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(accountName, accountKey))
            };

            return blobUriBuilder.ToUri().ToString();
        }

    }
}
