using Newtonsoft.Json;

namespace BookingSystem.Models
{
  public class UserRegisterModel
  {
    [JsonProperty("userName")]
    public string? UserName { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("createdDate")]
    public DateTime CreatedDate { get; set; }

    [JsonProperty("updatedDate")]
    public DateTime UpdatedDate { get; set; }
  }
}