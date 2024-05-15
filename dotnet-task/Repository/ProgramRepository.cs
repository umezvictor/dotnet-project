using dotnet_task.Domain.Models;
using dotnet_task.Exceptions;
using Microsoft.Azure.Cosmos;

namespace dotnet_task.Repository
{


    public class ProgramRepository : IProgramRepository
    {
        private readonly Container _container;

        public ProgramRepository(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);

            // Check if the database exists, if not, create it
            var databaseResponse = cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName).GetAwaiter().GetResult();

            // Check if the container exists, if not, create it
           databaseResponse.Database.CreateContainerIfNotExistsAsync(containerName, "/id").GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<InternshipProgram>> GetProgramsAsync()
        {
            var query = _container.GetItemQueryIterator<InternshipProgram>(new QueryDefinition("SELECT * FROM c"));
            var results = new List<InternshipProgram>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<InternshipProgram> GetProgramAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<InternshipProgram>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new CustomException("An internal server error occured");
            }
        }

        public async Task<InternshipProgram> CreateProgramAsync(InternshipProgram program)
        {
            var response = await _container.CreateItemAsync(program, new PartitionKey(program.Id));
            return response.Resource;

        }

        public async Task<InternshipProgram> UpdateProgramAsync(string id, InternshipProgram program)
        {
            var response = await _container.UpsertItemAsync(program, new PartitionKey(id));
            return response.Resource;
        }


    }

}
