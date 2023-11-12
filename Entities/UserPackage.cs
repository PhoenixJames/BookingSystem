using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Entities
{
  [Table("user_packages")]
  public class UserPackage 
  {

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("package_id")]
    public long PackageId { get; set; }

    [Column("user_credits")]
    public int UserCredits { get; set; }

    [Column("purchase_date")]
    public DateTime PurchaseDate { get; set; }

    [Column("expiry_date")]
    public DateTime ExpiryDate { get; set; }

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }

    [Column("updated_date")]
    public DateTime UpdatedDate { get; set; }
    public User User { get; set; }
    public Package Package { get; set; }
  }

}

