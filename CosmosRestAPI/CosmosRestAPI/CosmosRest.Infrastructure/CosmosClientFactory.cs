using System.ComponentModel;
using Azure.Cosmos;
using Azure.Cosmos.Serialization;

namespace CosmosRest.Infrastructure
{
    using Microsoft.Azure.Cosmos;

    namespace LOR.Forms.Infrastructure.Cosmos
    {
        public interface ICosmosClientFactory
        {
            CosmosContainer GetClient(string collectionName);
        }

        public class CosmosClientFactory : ICosmosClientFactory
        {
            private readonly CosmosClient _client;
            private readonly string _databaseName;

            public CosmosClientFactory(CosmosConfiguration configuration)
            {
                var clientOptions = new CosmosClientOptions()
                {
                    SerializerOptions = new CosmosSerializationOptions()
                    {
                        PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                    }
                };
                _client = new CosmosClient(
                    configuration.EndpointUrl,
                    configuration.PrimaryKey,
                    clientOptions
                );
                _databaseName = configuration.DatabaseName;
            }

            public CosmosContainer GetClient(string collectionName)
            {
                return _client.GetContainer(_databaseName, collectionName);
            }
        }
    }
}