using Newtonsoft.Json;

namespace BookingSystem.Models
{
  public class UserProfileModel
  {
    [JsonProperty("userId")]
    public long? userId { get; set; }

    [JsonProperty("firstName")]
    public string? FirstName { get; set; }

    [JsonProperty("lastName")]
    public string? LastName { get; set; }

    [JsonProperty("createdDate")]
    public DateTime CreatedDate { get; set; }

    [JsonProperty("updatedDate")]
    public DateTime UpdatedDate { get; set; }
  }
}