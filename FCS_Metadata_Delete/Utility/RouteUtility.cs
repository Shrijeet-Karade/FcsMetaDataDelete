using System;
using System.Linq;
using Tavisca.DataApis.Sdk;
using System.Threading.Tasks;
using FCS_Metadata_Delete.Models;
using FCS_Metadata_Delete.Translators;

namespace FCS_Metadata_Delete
{
    public static class RouteUtility
    {
        public static void InitiateDelete(IDataApiClientFactory dataApiClientFactory)
        {
            var applicationId = Helper.GetApplicationInfo(dataApiClientFactory);
            var appInstanceId = string.Empty;
            var isAppInstanceLevelData = Helper.IsAppInstanceLevelData();
            if (isAppInstanceLevelData)
                appInstanceId = Helper.GetApplicationInstanceInfo(dataApiClientFactory);

            Console.WriteLine("Please enter the name of the route you want to delete.");
            var routeName = Console.ReadLine();

            Console.WriteLine("\n Initiated : Get Route from store.");
            var route = GetRouteAsync(dataApiClientFactory,routeName, applicationId, appInstanceId);
            if (route != null)
            {
                Console.WriteLine("Finished : Get Route from store. \n");

                //Console.WriteLine($"Initiated: Delete links for route : {routeName}.");
                //DeleteMappingToRouteAsync(route.Id);
                //Console.WriteLine($"Finished : Delete links for route : {routeName}. \n ");

                Console.WriteLine($"Initiated : Delete route : {routeName}.");
                DeleteRouteAsync(dataApiClientFactory, route.Id);
                Console.WriteLine($"Finished : Delete route : {routeName}. \n");
            }
            else
                Console.WriteLine($"Aborted : Route with name {routeName} does not exist in the system.");
        }

        private static Route GetRouteAsync(IDataApiClientFactory dataApiClientFactory , string routeName, string appId, string appInstanceId)
        {
            try
            {
                var query = Query.Property(Constants.DataApiSchema.Route.Name).IsEqualTo(routeName);
                var dataApiClient = dataApiClientFactory.GetClientAsync();
                if (appInstanceId == null || appInstanceId == string.Empty)
                {
                    var result =  dataApiClient.GetConnectedObjectsAsync(Constants.DataApiSchema.Relation.ApplicationRoute,
                                                                                   Constants.DataApiSchema.Application.SchemaName, appId, query);
                    return result?.Result.Select(r => r.ToRouteModel()).FirstOrDefault();
                }
                else
                {
                    var result =  dataApiClient.GetConnectedObjectsAsync(Constants.DataApiSchema.Relation.AppInstanceRoute,
                                                                              Constants.DataApiSchema.ApplicationInstance.SchemaName, appInstanceId, query);
                    return result?.Result.Select(r => r.ToRouteModel()).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        private static void DeleteRouteAsync(IDataApiClientFactory dataApiClientFactory,string routeId)
        {
            try
            {
                var dataApiClient = dataApiClientFactory.GetClientAsync();
                dataApiClient.DeleteAsync(Constants.DataApiSchema.Route.SchemaName, routeId, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
