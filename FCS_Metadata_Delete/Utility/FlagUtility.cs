using System;
using System.Linq;
using System.Threading.Tasks;
using FCS_Metadata_Delete.Models;
using FCS_Metadata_Delete.Translators;

namespace FCS_Metadata_Delete
{
    public static class FlagUtility
    {
        public static void InitiateDelete(IDataApiClientFactory dataApiClientFactory)
        {
            var applicationId = Helper.GetApplicationInfo(dataApiClientFactory);
            var appInstanceId = string.Empty;
            var isAppInstanceLevelData = Helper.IsAppInstanceLevelData();
            if (isAppInstanceLevelData)
                appInstanceId = Helper.GetApplicationInstanceInfo(dataApiClientFactory);

            Console.WriteLine("\n Please enter the name of the feature whose flag you want to delete.");
            var featureName = Console.ReadLine();

            var feature = FeatureUtility.GetFeatureAsync( dataApiClientFactory ,featureName, applicationId, appInstanceId);

            Console.WriteLine("Initiated : Get Flag from store.");
            var flag = GetFlagAsync(dataApiClientFactory, feature.Id);
            if (flag != null)
            {
                Console.WriteLine("Finished : Get Flag from store. \n");

                //Console.WriteLine($"Initiated: Delete links for Flag : {flag.Id}.");
                //DeleteMappingToFlagAsync(flag.Id);
                //Console.WriteLine($"Finished : Delete links for Flag : {flag.Id}. \n ");

                Console.WriteLine($"Initiated : Delete Flag : {flag.Id}.");
                DeleteFlagAsync(dataApiClientFactory,flag.Id);
                Console.WriteLine($"Finished : Delete Flag : {flag.Id}. \n");
            }
            else
                Console.WriteLine($"Aborted : No Flag exist in the system for feature : {featureName}.");
        }

        public static FlagDefinition GetFlagAsync(IDataApiClientFactory dataApiClientFactory, string featureId)
        {
            try
            {
                var dataApiClient = dataApiClientFactory.GetClientAsync();
                var result = dataApiClient.GetConnectedObjectsAsync(Constants.DataApiSchema.Relation.FeatureFlag,
                                                                               Constants.DataApiSchema.Feature.SchemaName, featureId);
                var dataObject = result.Result.FirstOrDefault();
                return dataObject?.ToFlagDefinition();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static void DeleteFlagAsync(IDataApiClientFactory dataApiClientFactory,string flagId)
        {
            try
            {
                var dataApiClient = dataApiClientFactory.GetClientAsync();
                dataApiClient.DeleteAsync(Constants.DataApiSchema.Flag.SchemaName, flagId, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
