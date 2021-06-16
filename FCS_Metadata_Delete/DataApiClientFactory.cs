using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Tavisca.DataApis.Sdk;
using Tavisca.DataApis.Sdk.Interfaces;

namespace FCS_Metadata_Delete
{
    public class DataApiClientFactory : IDataApiClientFactory
    {
        public static string activeEnvironment = Constants.Environment.Qa; 
        private static readonly ConcurrentDictionary<string, IDataAPIClient> _clients = new ConcurrentDictionary<string, IDataAPIClient>();

        public IDataAPIClient GetClientAsync()
        {
            var environment = Constants.Environment.Qa;             
            var clientCacheKey = GetCacheKey(environment);
            IDataAPIClient client = null;
            if (_clients.TryGetValue(clientCacheKey, out client))
            {
                return client;
            }

            var apiOptions = GetApiOptions(environment);
            client = DataAPIClientFactory.GetClient(apiOptions);
            _clients.TryAdd(clientCacheKey, client);

            return client;
        }

        private ApiOptions GetApiOptions(string env)
        {
            if (env.Equals(Constants.Environment.Qa))
            {
                return new ApiOptions
                {
                    AppName = Constants.DataApiApplicationName,
                    CorrelationId = "fcs_metadata_delete_app",
                    TenantId = "2o9o3ae99ts",
                    HostUrl = "https://private-data.qa.oski.io/api/v1.0",
                    TimeOutInMs = 3000,
                    ConsistencyLevel = ConsistencyLevel.Immediate
                };
            }
            else if (env.Equals(Constants.Environment.Stage))
            {
                return new ApiOptions
                {
                    AppName = Constants.DataApiApplicationName,
                    CorrelationId = "fcs_metadata_delete_app",
                    TenantId = "2pq3iaipudc",
                    HostUrl = "https://private-data.stage.oski.io/api/v1.0",
                    TimeOutInMs = 3000,
                    ConsistencyLevel = ConsistencyLevel.Immediate
                };
            }
            else
                return null;
        }

        private static string GetCacheKey(string env)
        {
            return $"{env}";
        }
    }
}