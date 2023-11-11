using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Entities
{
  [Table("classes")]
  public class Class 
  {

    [Column("id")]
    public long Id { get; set; }

    [Column("country")]
    public string? Country { get; set; }

    [Column("class_name")]
    public string? ClassName { get; set; }

    [Column("class_date_time")]
    public DateTime ClassDateTime { get; set; }

    [Column("max_capacity")]
    public int MaxCapacity { get; set; }

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }

    [Column("updated_date")]
    public DateTime UpdatedDate { get; set; }
    public ICollection<UserClass> UserClasses { get; set; }
    public ICollection<Waitlist> Waitlists { get; set; }
  }

}

