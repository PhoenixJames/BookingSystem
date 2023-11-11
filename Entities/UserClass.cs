using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Entities
{
  public enum BookingStatus
  {
    Booked,
    Waitlisted,
    CheckedIn,
    Cancelled
  }

  [Table("user_classes")]
  public class UserClass
  {

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("class_id")]
    public long ClassId { get; set; }

    [Column("booking_date_time")]
    public DateTime BookingDateTime { get; set; }

    [Column("status")]
    public BookingStatus Status { get; set; } = BookingStatus.Booked;

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }

    [Column("updated_date")]
    public DateTime UpdatedDate { get; set; }
    public User User { get; set; }
    public Class Class { get; set; }
  }

}

