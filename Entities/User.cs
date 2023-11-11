using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Entities
{
  [Table("users")]
  public class User
  {
    [Column("id")]
    public long Id { get; set; }

    [Column("user_name")]
    public string? UserName { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("password")]
    public string? Password { get; set; }

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

