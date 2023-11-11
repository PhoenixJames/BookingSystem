using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Entities
{
  [Table("user_profile")]
  public class UserProfile
  {

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("first_name")]
    public string? FirstName { get; set; }

    [Column("last_name")]
    public string? LastName { get; set; }

    [Column("dob")]
    public string? DOB { get; set; }

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }

    [Column("updated_date")]
    public DateTime UpdatedDate { get; set; }
  }

}

