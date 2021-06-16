using System;
using System.Collections.Generic;

namespace FCS_Metadata_Delete.Models
{
    public class SettingDefinition
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public string DisplayName { get; set; }
        public object DefaultValue { get; set; }
        public List<object> PossibleValues { get; } = new List<object>();
        public string ValueType { get; set; }
        public string Description { get; set; }
        public List<string> TargetDevice { get; } = new List<string>();
        public bool IsValueCreationMandatory { get; set; }
        public List<string> Tags { get; } = new List<string>();
        public string AppInstanceName { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }

    }
}
