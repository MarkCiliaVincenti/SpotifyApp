using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpotifyApp.Api.Contracts.Tracks.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum AlbumGroupApi : byte
{
    [EnumMember(Value = "album")]
    Album = 0,
    
    [EnumMember(Value = "single")]
    Single = 1,
    
    [EnumMember(Value = "compilation")]
    Compilation = 2,
    
    [EnumMember(Value = "appears_on")]
    AppearsOn = 3,
}