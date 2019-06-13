using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UniversityManagementSystem.Apps.Blazor.Models
{
    public class Profile
    {
        [JsonProperty("sid")] public string Sid { get; set; }

        [JsonProperty("sub")] public Guid Sub { get; set; }

        [JsonProperty("auth_time")] public long AuthTime { get; set; }

        [JsonProperty("idp")] public string Idp { get; set; }

        [JsonProperty("amr")] public IEnumerable<string> Amr { get; set; }

        [JsonProperty("preferred_username")] public string PreferredUsername { get; set; }

        [JsonProperty("name")] public string Name { get; set; }
    }
}