using Tavisca.DataApis.Sdk;
using FCS_Metadata_Delete.Models;

namespace FCS_Metadata_Delete
{
    internal static class ApplicationInstanceTranslator
    {
        internal static ApplicationInstance ToAppInstanceModel(this DataObject dataObject)
        {
            return new ApplicationInstance
            {
                Id = dataObject.Id,
                Name = dataObject.GetAsString(Constants.DataApiSchema.ApplicationInstance.Name),
                DisplayName = dataObject.GetAsString(Constants.DataApiSchema.ApplicationInstance.DisplayName),
                Description = dataObject.GetAsString(Constants.DataApiSchema.ApplicationInstance.Description),
                CreatedAtUtc = dataObject.CreatedAt,
                UpdatedAtUtc = dataObject.LastUpdatedAt
            };
        }
    }
}
