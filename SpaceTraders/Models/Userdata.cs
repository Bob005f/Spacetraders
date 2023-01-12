using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpaceTraders.Userdata
{
    public partial class MyAccountDto
    {
      [JsonProperty("user")]
      public UserDto User { get; set; }
    }

    public partial class UserDto
    {
      [JsonProperty("username")]
      public string Username { get; set; }

      [JsonProperty("shipCount")]
      public long ShipCount { get; set; }

      [JsonProperty("structureCount")]
      public long StructureCount { get; set; }

      [JsonProperty("joinedAt")]
      public DateTimeOffset JoinedAt { get; set; }

      [JsonProperty("credits")]
      public long Credits { get; set; }
    }

    public partial class MyAccountDto
    {
      public static MyAccountDto FromJson(string json) => JsonConvert.DeserializeObject<MyAccountDto>(json, SpaceTraders.Userdata.Converter.Settings);
    }

    public static class Serialize
    {
      public static string ToJson(this MyAccountDto self) => JsonConvert.SerializeObject(self, SpaceTraders.Userdata.Converter.Settings);
    }

    internal static class Converter
    {
      public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
      {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
      };
    }
}
