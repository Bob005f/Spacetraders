using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace SpaceTraders.LoanedLoans
{
  public partial class LoanedLoansDTO
  {
    [JsonProperty("loans")]
    public Loan[] Loans { get; set; }
  }

  public partial class Loan
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("due")]
    public DateTimeOffset Due { get; set; }

    [JsonProperty("repaymentAmount")]
    public long RepaymentAmount { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    public string DueDays()
    {
      DateTime Due = this.Due.UtcDateTime;
      TimeSpan ts = Due.Subtract(DateTime.Now);
      if (ts.Days > 0) 
      { 
        return ts.ToString("%d") + " days, " + ts.ToString(@"hh\:mm\:ss");
      } 
      else
      { 
        return ts.ToString(@"hh\:mm\:ss");
      }
    }
  }

  public partial class LoanedLoansDTO
  {
    public static LoanedLoansDTO FromJson(string json) => JsonConvert.DeserializeObject<LoanedLoansDTO>(json, SpaceTraders.LoanedLoans.Converter.Settings);
  }

  public static class Serialize
  {
    public static string ToJson(this LoanedLoansDTO self) => JsonConvert.SerializeObject(self, SpaceTraders.LoanedLoans.Converter.Settings);
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

