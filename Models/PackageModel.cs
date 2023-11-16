using Newtonsoft.Json;

namespace BookingSystem.Models
{

  public class PackageModel
  {

    [JsonProperty("packageId")]
    public long PackageId { get; set; }

    [JsonProperty("country")]
    public string? Country { get; set; }

    [JsonProperty("packageName")]
    public string? PackageName { get; set; }

    [JsonProperty("credits")]
    public int Credits { get; set; }

    [JsonProperty("price")]
    public int Price { get; set; }

    [JsonProperty("duration")]
    public int Duration { get; set; }

    [JsonProperty("isActive")]
    public bool IsActive { get; set; }

    [JsonProperty("createdDate")]
    public DateTime CreatedDate { get; set; }

    [JsonProperty("updatedDate")]
    public DateTime UpdatedDate { get; set; }
  }

  public class PurchasePackageModel
  {

    [JsonProperty("userId")]
    public long UserId { get; set; }

    [JsonProperty("packageId")]
    public long PackageId { get; set; }

    [JsonProperty("purchaseDate")]
    public DateTime? PurchaseDate  { get; set; }

    [JsonProperty("expiryDate")]
    public DateTime? ExpiryDate { get; set; }

    [JsonProperty("userCredits")]
    public int? UserCredits { get; set; }

    [JsonProperty("createdDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonProperty("updatedDate")]
    public DateTime? UpdatedDate { get; set; }
  }
}