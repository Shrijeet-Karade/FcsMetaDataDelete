using System;
using System.Linq;
using Tavisca.DataApis.Sdk;
using System.Threading.Tasks;
using FCS_Metadata_Delete.Models;
using FCS_Metadata_Delete.Translators;

namespace FCS_Metadata_Delete
{
    public static class FeatureUtility
    {
        public static void InitiateDelete(IDataApiClientFactory dataApiClientFactory)
        {
            var applicationId = Helper.GetApplicationInfo(dataApiClientFactory);
            var appInstanceId = string.Empty;
            var isAppInstanceLevelData = Helper.IsAppInstanceLevelData();
            if (isAppInstanceLevelData)
                appInstanceId = Helper.GetApplicationInstanceInfo(dataApiClientFactory);

            Console.WriteLine("Please enter the name of the feature you want to delete.");
            var featureName = Console.ReadLine();

            Console.WriteLine("\n Initiated : Get Feature from store.");
            var feature = GetFeatureAsync(dataApiClientFactory, featureName, applicationId, appInstanceId );
            if (feature != null)
            {
                Console.WriteLine("Finished : Get Feature from store. \n");

                FetchAndDeleteFlagByFeatureName(dataApiClientFactory,feature);

                //Console.WriteLine($"Initiated: Delete links for feature : {featureName}.");
                //DeleteMappingToFeatureAsync(feature.Id);
                //Console.WriteLine($"Finished : Delete links for feature : {featureName}. \n ");

                Console.WriteLine($"Initiated : Delete feature : {featureName}.");
                DeleteFeatureAsync(dataApiClientFactory,feature.Id);
                Console.WriteLine($"Finished : Delete Feature : {featureName}. \n");
            }
            else
                Console.WriteLine($"Aborted : No feature with name : {featureName} exist in the system.");
        }

        public static void FetchAndDeleteFlagByFeatureName(IDataApiClientFactory dataApiClientFactory,Feature feature)
        {
            Console.WriteLine($"Checking if a flag exists for feature : {feature.Name}.");
            var flag = FlagUtility.GetFlagAsync(dataApiClientFactory ,feature.Id);
            if (flag != null)
            {
                Console.WriteLine("Confirmed : Flag exist for this feature.");

                //Console.WriteLine($"Initiated: Delete links for Flag : {flag.Name}.");
                //FlagUtility.DeleteMappingToFlagAsync(flag.Id);
                //Console.WriteLine($"Finished : Delete links for Flag : {flag.Name}. \n ");

                Console.WriteLine($"Initiated : Delete Flag :{flag.Name} associated to feature : {feature.Name}.");
                FlagUtility.DeleteFlagAsync(dataApiClientFactory,flag.Id);
                Console.WriteLine($"Finished : Delete Flag : {flag.Name} associated to feature : {feature.Name}.\n");
            }
            else
                Console.WriteLine($"Confirmed : Flag does not exist for this feature.");
        }

        public static Feature GetFeatureAsync(IDataApiClientFactory dataApiClientFactory, string featureName, string applicationId, string appInstanceId = null)
        {
            try
            {
                var query = Query.Property(Constants.DataApiSchema.Feature.Name).IsEqualTo(featureName);
                var dataApiClient = dataApiClientFactory.GetClientAsync();
                if (appInstanceId == null || appInstanceId == string.Empty)
                {
                    var result = dataApiClient.GetConnectedObjectsAsync(Constants.DataApiSchema.Relation.ApplicationFeature,
                                                                                   Constants.DataApiSchema.Application.SchemaName, applicationId, query);
                    return result?.Result.Select(r => r.ToFeatureModel()).FirstOrDefault();
                }
                else
                {
                    var result =  dataApiClient.GetConnectedObjectsAsync(Constants.DataApiSchema.Relation.AppInstanceFeature,
                                                                              Constants.DataApiSchema.ApplicationInstance.SchemaName, appInstanceId, query);
                    return result?.Result.Select(r => r.ToFeatureModel()).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        private static void DeleteFeatureAsync(IDataApiClientFactory dataApiClientFactory,string id)
        {
            try
            {
                var dataApiClient = dataApiClientFactory.GetClientAsync();
                dataApiClient.DeleteAsync(Constants.DataApiSchema.Feature.SchemaName, id, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
