using System.Text.Json.Serialization;

namespace SpaceTraders.ErrorDto
{
    public class ErrorDTO
    {
    [JsonPropertyName("error")]
    public MessageDto Error { get; set; }
  }
  public class MessageDto
  {
    [JsonPropertyName("message")]
    public string Message { get; set; }
    [JsonPropertyName("code")]
    public int Code { get; set; }
  }
}
