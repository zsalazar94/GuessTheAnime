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

        public string GenerateSasTokenForContainer(int durationMinutes = 60)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            BlobSasBuilder sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                Resource = "c", // "c" for container
                StartsOn = DateTimeOffset.UtcNow,
                ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(durationMinutes)
            };

            // Specify read permissions for the SAS
            sasBuilder.SetPermissions(BlobContainerSasPermissions.List | BlobContainerSasPermissions.Read);

            // Build the SAS token
            string sasToken = sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(accountName, accountKey)).ToString();

            return sasToken;
        }

        public string GetBlobSasUri(string blobPath, string sasToken)
        {
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobPath);

            // Combine the blob URI with the SAS token
            return $"{blobClient.Uri}?{sasToken}";
        }
    }
}
