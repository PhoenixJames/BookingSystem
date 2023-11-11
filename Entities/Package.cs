using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Entities
{
  [Table("packages")]
  public class Package 
  {

    [Column("id")]
    public long Id { get; set; }

    [Column("country")]
    public string? Country { get; set; }

    [Column("package_name")]
    public string? PackageName { get; set; }

    [Column("credits")]
    public int Credits { get; set; }

    [Column("price")]
    public int Price { get; set; }

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }

    [Column("updated_date")]
    public DateTime UpdatedDate { get; set; }
    public ICollection<UserPackage> UserPackages { get; set; }

  }

}

