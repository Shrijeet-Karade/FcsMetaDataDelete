using FCS_Metadata_Delete.Models;
using Tavisca.DataApis.Sdk;

namespace FCS_Metadata_Delete.Translators
{
    internal static class RouteTranslator
    {
        internal static Route ToRouteModel(this DataObject dataObject)
        {
            var response = new Route
            {
                Id = dataObject.Id,
                Name = dataObject.GetAsString(Constants.DataApiSchema.Route.Name),
                Description = dataObject.GetAsString(Constants.DataApiSchema.Route.Description),
                DisplayName = dataObject.GetAsString(Constants.DataApiSchema.Route.DisplayName),
                AppInstanceName = dataObject.GetAsStringIfNotNullOrWhiteSpace(Constants.DataApiSchema.Route.AppInstanceName),
                CreatedAtUtc = dataObject.CreatedAt,
                UpdatedAtUtc = dataObject.LastUpdatedAt
            };           
            return response;
        }
        private static string GetAsStringIfNotNullOrWhiteSpace(this DataObject dataObject, string name)
        {
            var value = dataObject.GetAsString(name, null);
            if (string.IsNullOrWhiteSpace(value))
                value = null;

            return value;
        }
    }
}
