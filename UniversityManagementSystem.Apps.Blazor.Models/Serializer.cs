using static Newtonsoft.Json.JsonConvert;
using static UniversityManagementSystem.Apps.Blazor.Models.Converter;

namespace UniversityManagementSystem.Apps.Blazor.Models
{
    public static class Serializer
    {
        public static string ToJson(this User user)
        {
            return SerializeObject(user, Settings);
        }
    }
}