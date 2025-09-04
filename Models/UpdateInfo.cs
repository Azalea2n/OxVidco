using System;
using Newtonsoft.Json;

namespace OxVidco.Models
{
    public class UpdateInfo
    {
        [JsonProperty("version")]
        public string VersionString { get; set; } = string.Empty;

        [JsonIgnore]
        public Version? Version => Version.TryParse(VersionString, out var version) ? version : null;

        [JsonProperty("downloadUrl")]
        public string DownloadUrl { get; set; } = string.Empty;

        [JsonProperty("changelog")]
        public string Changelog { get; set; } = string.Empty;

        [JsonProperty("isMandatory")]
        public bool IsMandatory { get; set; }

        [JsonProperty("releaseDate")]
        public DateTime ReleaseDate { get; set; }
    }
}
