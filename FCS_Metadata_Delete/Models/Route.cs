using System;

namespace FCS_Metadata_Delete.Models
{
    public class Route
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AppInstanceName { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
    }
}
