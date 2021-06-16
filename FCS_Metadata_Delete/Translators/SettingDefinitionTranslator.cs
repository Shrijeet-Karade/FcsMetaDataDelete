using FCS_Metadata_Delete.Models;
using System.Linq;
using Tavisca.DataApis.Sdk;

namespace FCS_Metadata_Delete.Translators
{
    internal static class SettingDefinitionTranslator
    {
        internal static SettingDefinition ToSettingDefinition(this DataObject dataObject)
        {
            var valueType = dataObject.GetAsString(Constants.DataApiSchema.Setting.ValueType);

            var definition = new SettingDefinition
            {
                Id = dataObject.Id,
                Key = dataObject.GetAsString(Constants.DataApiSchema.Setting.Key),
                Description = dataObject.GetAsString(Constants.DataApiSchema.Setting.Description),
                DisplayName = dataObject.GetAsString(Constants.DataApiSchema.Setting.DisplayName),
                ValueType = valueType,
                AppInstanceName = dataObject.GetAsStringIfNotNullOrWhiteSpace(Constants.DataApiSchema.Setting.AppInstanceName),
                IsValueCreationMandatory = dataObject.GetAsBoolean(Constants.DataApiSchema.Setting.IsValueCreationMandatory),
                CreatedAtUtc = dataObject.CreatedAt,
                UpdatedAtUtc = dataObject.LastUpdatedAt
            };
           
            var targetDevice = dataObject.GetList<string>(Constants.DataApiSchema.Setting.TargetDevice)?.ToList();
            var tags = dataObject.GetList<string>(Constants.DataApiSchema.Setting.Tags)?.ToList();

            if (targetDevice != null)
                definition.TargetDevice.AddRange(targetDevice);

            if (tags != null)
                definition.Tags.AddRange(tags); 
            
            //if(definition.IsValueCreationMandatory == false)
            //{
            //    var defaultValue = JsonConvert.DeserializeObject<JsonToken>(dataObject.GetAsJsonToken(Constants.DataApiSchema.Setting.DefaultValue).Value).Value;
            //    definition.DefaultValue = ConfigurationParser.ParseValue(valueType, defaultValue);
            //}

            //var possibleValues = dataObject.GetList<string>(Constants.DataApiSchema.Setting.PossibleValues)?.ToList();
            //definition.PossibleValues.AddRange(ConfigurationParser.ParsePossibleValues(valueType, possibleValues));
            return definition;
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