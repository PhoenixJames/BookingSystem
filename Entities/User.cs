using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Entities
{
  [Table("users")]
  public class User
  {
    [Column("user_id")]
    public long UserId { get; set; }

    [Column("user_name")]
    public string? UserName { get; set; }

    [Column("country")]
    public string? Country { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("password")]
    public string? Password { get; set; }
    
    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }

    [Column("updated_date")]
    public DateTime UpdatedDate { get; set; }
    public UserProfile Profile { get; set; }
    public ICollection<UserPackage> Packages { get; set; }
    public ICollection<UserClass> Classes { get; set; }
    public ICollection<Waitlist> Waitlists { get; set; }
  }

}

