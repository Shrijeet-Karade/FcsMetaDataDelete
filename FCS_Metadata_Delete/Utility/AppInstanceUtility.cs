using FCS_Metadata_Delete.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tavisca.DataApis.Sdk;

namespace FCS_Metadata_Delete
{
    public static class AppInstanceUtility
    {
        public static ApplicationInstance GetApplicationInstance (IDataApiClientFactory dataApiClientFactory, string name)
        {
            try
            {
                var dataApiClient =  dataApiClientFactory.GetClientAsync();
                var query = Query.Property(Constants.DataApiSchema.ApplicationInstance.Name).MatchOneOrMore(name);
                                                                             
                var dataApiResponse = dataApiClient.FindAsync(Constants.DataApiSchema.ApplicationInstance.SchemaName, query,
                                                                    null, pageNumber: 1, pageSize: Constants.DefaultPageSize);
                return dataApiResponse.Result.FirstOrDefault().ToAppInstanceModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
