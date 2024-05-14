using dotnet_task.Domain.Models;
using Microsoft.Azure.Cosmos;

namespace dotnet_task.Repository
{

    public class ApplicationRepository : IApplicationRepository
    {
        private readonly Container _container;

        public ApplicationRepository(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);

            // Check if the database exists, if not, create it
            var databaseResponse = cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName).GetAwaiter().GetResult();

            // Check if the container exists, if not, create it
            databaseResponse.Database.CreateContainerIfNotExistsAsync(containerName, "/id").GetAwaiter().GetResult();
        }

        public async Task<Applications> CreateApplicationAsync(Applications application)
        {
            var response = await _container.CreateItemAsync(application, new PartitionKey(application.Id));
            return response.Resource;

        }

    }

}
