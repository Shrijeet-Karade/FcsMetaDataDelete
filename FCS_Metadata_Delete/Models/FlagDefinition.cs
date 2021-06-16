using System;
using System.Collections.Generic;

namespace FCS_Metadata_Delete.Models
{
    public class FlagDefinition
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsValueCreationMandatory { get; set; }
        public object DefaultValue { get; set; }
        public List<string> PossibleValues { get; } = new List<string>();
        public string DisplayName { get; set; }
        public FlagType Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
    }
}
