using Newtonsoft.Json;
using static Newtonsoft.Json.JsonConvert;
using static UniversityManagementSystem.Apps.Blazor.Models.Converter;

namespace UniversityManagementSystem.Apps.Blazor.Models
{
    public class User
    {
        [JsonProperty("id_token")] public string IdToken { get; set; }

        [JsonProperty("session_state")] public string SessionState { get; set; }

        [JsonProperty("access_token")] public string AccessToken { get; set; }

        [JsonProperty("token_type")] public string TokenType { get; set; }

        [JsonProperty("scope")] public string Scope { get; set; }

        [JsonProperty("profile")] public Profile Profile { get; set; }

        [JsonProperty("expires_at")] public long ExpiresAt { get; set; }

        public static User FromJson(string json)
        {
            return DeserializeObject<User>(json, Settings);
        }
    }
}