using System;
using System.Collections.Generic;
using System.Linq;

namespace FCS_Metadata_Delete.Models
{
    public class Feature
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public List<string> TargetDevice { get; } = new List<string>();
        public List<string> Tags { get; } = new List<string>();
        public string AppInstanceName { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }

    }
}
