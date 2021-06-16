using System;
using System.Linq;
using Tavisca.DataApis.Sdk;
using System.Threading.Tasks;
using FCS_Metadata_Delete.Models;
using FCS_Metadata_Delete.Translators;

namespace FCS_Metadata_Delete
{
    public static class SettingUtility
    {
        public static void InitiateDelete(IDataApiClientFactory dataApiClientFactory)
        {
            var applicationId = Helper.GetApplicationInfo(dataApiClientFactory);
            var appInstanceId = string.Empty;
            var isAppInstanceLevelData = Helper.IsAppInstanceLevelData();
            if (isAppInstanceLevelData)
                appInstanceId = Helper.GetApplicationInstanceInfo(dataApiClientFactory);

            Console.WriteLine("Please enter the name of the setting you want to delete.");
            var setting = Console.ReadLine();

            Console.WriteLine("\n Initiated : Get Setting from store.");
            var settingDefinition = GetSettingAsync(dataApiClientFactory,setting,applicationId,appInstanceId);
            if (settingDefinition != null)
            {
                Console.WriteLine("Finished : Get Setting from store. \n");

                //Console.WriteLine($"Initiated: Delete links for setting : {setting}.");
                //DeleteMappingToSettingAsync(settingDefinition.Id);
                //Console.WriteLine($"Finished : Delete links for setting : {setting}. \n ");

                Console.WriteLine($"Initiated : Delete setting : {setting}.");
                DeleteSettingAsync(dataApiClientFactory,settingDefinition.Id);
                Console.WriteLine($"Finished : Delete setting : {setting}. \n");
            }
            else
                Console.WriteLine($"Aborted : Setting with name : {setting} does not exist in the system.");
           
        }

        private static void DeleteSettingAsync(IDataApiClientFactory dataApiClientFactory,string id)
        {
            try
            {
                var dataApiClient = dataApiClientFactory.GetClientAsync();
                dataApiClient.DeleteAsync(Constants.DataApiSchema.Setting.SchemaName, id, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static SettingDefinition GetSettingAsync(IDataApiClientFactory dataApiClientFactory, string key, string applicationId, string appInstanceId)
        {
            try
            {
                var query = Query.Property(Constants.DataApiSchema.Setting.Key).IsEqualTo(key);
                var dataApiClient = dataApiClientFactory.GetClientAsync();
                if (appInstanceId == null || appInstanceId == string.Empty)
                {
                    var result =  dataApiClient.GetConnectedObjectsAsync(Constants.DataApiSchema.Relation.ApplicationSetting,
                                                                                   Constants.DataApiSchema.Application.SchemaName, applicationId, query);
                    return result?.Result.Select(r => r.ToSettingDefinition()).FirstOrDefault();
                }
                else
                {
                    var result =  dataApiClient.GetConnectedObjectsAsync(Constants.DataApiSchema.Relation.AppInstanceSetting,
                                                                              Constants.DataApiSchema.ApplicationInstance.SchemaName, appInstanceId, query);
                    return result?.Result.Select(r => r.ToSettingDefinition()).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
