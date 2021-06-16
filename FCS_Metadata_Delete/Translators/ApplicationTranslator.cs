using Tavisca.DataApis.Sdk;
using FCS_Metadata_Delete.Models;

namespace FCS_Metadata_Delete
{
    internal static class ApplicationTranslator
    {
        internal static Application ToApplicationModel(this DataObject dataObject)
        {
            return new Application
            {
                Id = dataObject.Id,
                Name = dataObject.GetAsString(Constants.DataApiSchema.Application.Name),
                DisplayName = dataObject.GetAsString(Constants.DataApiSchema.Application.DisplayName),
                Description = dataObject.GetAsString(Constants.DataApiSchema.Application.Description),
                AccountId = dataObject.GetAsString(Constants.DataApiSchema.Application.AccountId),
                CreatedAtUtc = dataObject.CreatedAt,
                UpdatedAtUtc = dataObject.LastUpdatedAt
            };
        }
    }
}
