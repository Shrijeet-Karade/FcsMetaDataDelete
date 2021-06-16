using FCS_Metadata_Delete.Models;
using System;
using Tavisca.DataApis.Sdk;

namespace FCS_Metadata_Delete.Translators
{
    internal static class FlagDefinitionTranslator
    {
        internal static FlagDefinition ToFlagDefinition(this DataObject dataObject)
        {
            var flagDefintion = new FlagDefinition
            {
                Id = dataObject.Id,
                Name = dataObject.GetAsString(Constants.DataApiSchema.Flag.Name),
                Description = dataObject.GetAsString(Constants.DataApiSchema.Flag.Description),
                DisplayName = dataObject.GetAsString(Constants.DataApiSchema.Flag.DisplayName),
                IsValueCreationMandatory = dataObject.GetAsBoolean(Constants.DataApiSchema.Flag.IsValueCreationMandatory),
                CreatedAtUtc = dataObject.CreatedAt,
                UpdatedAtUtc = dataObject.LastUpdatedAt
            };
            var flagType = dataObject.GetAsString(Constants.DataApiSchema.Flag.Type);
            flagDefintion.Type = ParseFlagTypeValue(flagType);

            if (flagDefintion.Type.Equals(FlagType.Boolean))
            {
                flagDefintion.DefaultValue = dataObject.GetAsBoolean(Constants.DataApiSchema.Flag.DefaultValue, false);
            }
            else
            {
                flagDefintion.DefaultValue = dataObject.GetAsStringIfNotNullOrWhiteSpace(Constants.DataApiSchema.Flag.DefaultValue);
            }
            
            flagDefintion.PossibleValues.AddRange(dataObject.GetList<string>(Constants.DataApiSchema.Flag.PossibleValues));
            return flagDefintion;
        }
        

        private static FlagType ParseFlagTypeValue(string flagType)
        {
            switch(flagType.ToLower())
            {
                case "boolean":
                    return FlagType.Boolean;
                case "multivariant":
                    return FlagType.Multivariant;
                default:
                    throw new ArgumentException($"Found invalid value in FlagType: {flagType}.");
            }
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