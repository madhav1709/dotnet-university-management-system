using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static Newtonsoft.Json.DateParseHandling;
using static Newtonsoft.Json.MetadataPropertyHandling;

namespace UniversityManagementSystem.Apps.Blazor.Models
{
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = Ignore,
            DateParseHandling = None,
            Converters =
            {
                new IsoDateTimeConverter
                {
                    DateTimeStyles = DateTimeStyles.AssumeUniversal
                }
            }
        };
    }
}