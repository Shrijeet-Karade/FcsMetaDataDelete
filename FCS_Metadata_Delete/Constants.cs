namespace FCS_Metadata_Delete
{
    internal static class Constants
    {
        internal static class Environment
        {
            internal const string Qa = "qa";
            internal const string Stage = "stage";
            internal const string Prod = "prod";
        }

        internal const string DataApiApplicationName = "nextgen_featureconfiguration_service";
        internal const int DefaultPageSize = 50;
        internal const string DefaultTenantId = "default_tenant_id";
        internal const string PersistentStore = "dataStore";

        internal static class DataApiSchema
        {
            internal const string FacetPrefix = "facet_";
            internal const string UtcCreatedOn = "__utcCreatedOn"; 
            
            internal static class Relation
            {
                internal const string ApplicationFeature = "applicationFeature";
                internal const string AppInstanceFeature = "appInstanceFeature";
                internal const string ApplicationRoute = "applicationRoute";
                internal const string ApplicationSetting = "applicationSetting";
                internal const string AppInstanceSetting = "appInstanceSetting";
                internal const string FeatureFlag = "featureFlag";
                internal const string FeatureSetting = "featureSetting";
                internal const string FeatureRoute = "featureRoute";
                internal const string RouteSetting = "routeSetting";
                internal const string ApplicationAppInstance = "applicationAppInstance";
                internal const string AppInstanceRoute = "appInstanceRoute";
            }

            internal static class Application
            {
                internal const string SchemaName = "application";
                internal const string DisplayName = "displayName";
                internal const string Name = "name";
                internal const string Description = "desc";
                internal const string AccountId = "accountId";
            }

            internal static class ApplicationInstance
            {
                internal const string SchemaName = "appInstance";
                internal const string DisplayName = "displayName";
                internal const string Name = "name";
                internal const string Description = "desc";
            }

            internal static class Feature
            {
                internal const string SchemaName = "feature";
                internal const string Name = "name";
                internal const string Desc = "desc";
                internal const string DisplayName = "displayName";
                internal const string FeatureId = "featureId";
                internal const string TargetDevice = "targetDevice";
                internal const string Tags = "tags";
                internal const string AppInstanceName = "appInstanceName";
            }

            internal static class Flag
            {
                internal const string SchemaName = "flag";
                internal const string Name = "name";
                internal const string Description = "desc";
                internal const string DisplayName = "displayName";
                internal const string Type = "type";
                internal const string IsValueCreationMandatory = "isValueCreationMandatory";
                internal const string DefaultValue = "defaultValue";
                internal const string PossibleValues = "possibleValues";
            }

            internal static class Setting
            {
                internal const string SchemaName = "setting";
                internal const string Key = "key";
                internal const string Description = "desc";
                internal const string ValueType = "valueType";
                internal const string DefaultValue = "defaultValue";
                internal const string DisplayName = "displayName";
                internal const string TargetDevice = "targetDevice";
                internal const string IsValueCreationMandatory = "isValueCreationMandatory";
                internal const string Tags = "tags";
                internal const string PossibleValues = "possibleValues";
                internal const string AppInstanceName = "appInstanceName";
            }

            internal static class Route
            {
                internal const string SchemaName = "route";
                internal const string Name = "name";
                internal const string Description = "desc";
                internal const string DisplayName = "displayName";
                internal const string AppInstanceName = "appInstanceName";
            }

        }
    }
}
