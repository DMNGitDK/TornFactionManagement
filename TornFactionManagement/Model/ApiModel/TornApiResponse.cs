using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TornFactionManagement.Model.ApiModel
{
    internal class TornApiResponse
    {
        [JsonPropertyName("members")]
        public List<TornApiResponseMembers>? Members { get; set; }

    }

    public class TornApiResponseMembers
    {
        public string? Name { get; set; }
        public int Level { get; set; }
        public int Days_in_faction { get; set; }
        public Last_Action? Last_action { get; set; }
        public Status? Status { get; set; }
        public string? Position { get; set; }
    }

    public class Last_Action
    {
        public string? Status { get; set; }
        public int Timestamp { get; set; }
        public string? Relative { get; set; }
    }

    public class Status
    {
        public string? Description { get; set; }
        public string? Details { get; set; }
        public string? State { get; set; }
        public string? Color { get; set; }
        public int? Until { get; set; }
    }

}