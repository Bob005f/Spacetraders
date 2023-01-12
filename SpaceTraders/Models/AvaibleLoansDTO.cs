using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpaceTraders.Loans
{
  public partial class AvaibleLoansDTO
  {
    [JsonProperty("loans")]
    public LoanDTO[] Loans { get; set; }
  }

  public partial class LoanDTO
  {
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("amount")]
    public long Amount { get; set; }

    [JsonProperty("rate")]
    public long Rate { get; set; }

    [JsonProperty("termInDays")]
    public long TermInDays { get; set; }

    [JsonProperty("collateralRequired")]
    public bool CollateralRequired { get; set; }
  }

  public partial class AvaibleLoansDTO
  {
    public static AvaibleLoansDTO FromJson(string json) => JsonConvert.DeserializeObject<AvaibleLoansDTO>(json, SpaceTraders.Loans.Converter.Settings);
  }

  public static class Serialize
  {
    public static string ToJson(this AvaibleLoansDTO self) => JsonConvert.SerializeObject(self, SpaceTraders.Loans.Converter.Settings);
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
