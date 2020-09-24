namespace MediaCore
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos;

    public class MediaService : IMediaService
    {
        private Container _container;

        public MediaService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }
        
        public async Task AddItemAsync(Media item)
        {
            await this._container.CreateItemAsync<Media>(item, new PartitionKey(item.Genre));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<Media>(id, new PartitionKey(id));
        }

        public async Task<Media> GetItemAsync(string id)
        {
            try
            {
                var response = await this._container.ReadItemAsync<Media>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch(CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            { 
                return null;
            }

        }

        public async Task<IEnumerable<Media>> GetItemsAsync(string queryString)
        {
            queryString = "select * from c";
            var query = this._container.GetItemQueryIterator<Media>(new QueryDefinition(queryString));
            List<Media> results = new List<Media>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, Media item)
        {
            await this._container.UpsertItemAsync<Media>(item, new PartitionKey(id));
        }
    }
}