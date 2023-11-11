using Newtonsoft.Json;

namespace BookingSystem.Models
{

  public class UserModel
  {

    [JsonProperty("userId")]
    public long? UserId { get; set; }

    [JsonProperty("userName")]
    public string? UserName { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("firstName")]
    public string? FirstName { get; set; }

    [JsonProperty("lastName")]
    public string? LastName { get; set; }

    [JsonProperty("dob")]
    public string? DOB { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("createdDate")]
    public DateTime CreatedDate { get; set; }

    [JsonProperty("updatedDate")]
    public DateTime UpdatedDate { get; set; }

    [JsonProperty("accessToken")]
    public string? AccessToken { get; set; }
  }
  public class UserRegisterModel
  {

    [JsonProperty("userId")]
    public long? UserId { get; set; }

    [JsonProperty("userName")]
    public string? UserName { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("firstName")]
    public string? FirstName { get; set; }

    [JsonProperty("lastName")]
    public string? LastName { get; set; }

    [JsonProperty("dob")]
    public string? DOB { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }

    [JsonProperty("createdDate")]
    public DateTime CreatedDate { get; set; }

    [JsonProperty("updatedDate")]
    public DateTime UpdatedDate { get; set; }
  }
  public class UserLoginModel
  {
    [JsonProperty("userName")]
    public string? UserName { get; set; }

    [JsonProperty("password")]
    public string? Password { get; set; }
  }
}