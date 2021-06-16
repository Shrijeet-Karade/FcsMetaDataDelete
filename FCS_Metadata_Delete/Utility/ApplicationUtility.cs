using FCS_Metadata_Delete.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.DataApis.Sdk;

namespace FCS_Metadata_Delete
{
    public static class ApplicationUtility
    {
        public static Application GetApplication(IDataApiClientFactory dataApiClientFactory, string name)
        {
            try
            {
                var dataApiClient = dataApiClientFactory.GetClientAsync();
                var query = Query.Property(Constants.DataApiSchema.Application.Name).MatchOneOrMore(name);

                var dataApiResponse = dataApiClient.FindAsync(Constants.DataApiSchema.Application.SchemaName, query,
                                                                    null, pageNumber: 1, pageSize: Constants.DefaultPageSize);

                return dataApiResponse.Result.FirstOrDefault().ToApplicationModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
