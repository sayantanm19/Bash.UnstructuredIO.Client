using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UnstructuredAPI.Models
{
    public partial class ErrorDetail
    {
        [JsonPropertyName("detail")]
        public string? Detail { get; set; }
    }
    public partial class ErrorDetails
    {
        [JsonPropertyName("detail")]
        public List<Detail>? Detail { get; set; }
    }

    public partial class Detail
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("loc")]
        public List<string>? Loc { get; set; }

        [JsonPropertyName("msg")]
        public string? Msg { get; set; }

        [JsonPropertyName("input")]
        public string? Input { get; set; }

        [JsonPropertyName("ctx")]
        public Context? Ctx { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }

    public partial class Context
    {
        [JsonPropertyName("expected")]
        public string? Expected { get; set; }
    }

    public partial class ErrorMessage
    {
        [JsonPropertyName("detail")]
        public List<Detail>? Detail { get; set; }
    }
}
