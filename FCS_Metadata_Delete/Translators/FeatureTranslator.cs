using FCS_Metadata_Delete.Models;
using System.Linq;
using Tavisca.DataApis.Sdk;

namespace FCS_Metadata_Delete.Translators
{
    internal static class FeatureTranslator
    {
        internal static Feature ToFeatureModel(this DataObject dataObject)
        {
            var feature = new Feature
            {
                Id = dataObject.Id,
                Name = dataObject.GetAsString(Constants.DataApiSchema.Feature.Name),
                Description = dataObject.GetAsString(Constants.DataApiSchema.Feature.Desc),
                DisplayName = dataObject.GetAsString(Constants.DataApiSchema.Feature.DisplayName),
                AppInstanceName = dataObject.GetAsStringIfNotNullOrWhiteSpace(Constants.DataApiSchema.Feature.AppInstanceName),
                CreatedAtUtc = dataObject.CreatedAt,
                UpdatedAtUtc = dataObject.LastUpdatedAt
            };
            var targetDevice = dataObject.GetList<string>(Constants.DataApiSchema.Feature.TargetDevice)?.ToList();
            var tags = dataObject.GetList<string>(Constants.DataApiSchema.Feature.Tags)?.ToList();
      
            if (targetDevice != null)           
                feature.TargetDevice.AddRange(targetDevice);            
            if (tags != null)            
                feature.Tags.AddRange(tags);
            
            return feature;
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
