
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ef_core2.Models;


public enum BadgeTier
{
    Standard = 0,
    VIP = 1
}

// Technique: Fluent API (separate configuration class)
public class Badge
{
    public int Id { get; set; }
    public string BadgeNumber { get; set; } = null!;   // unique number
    public DateTime IssuedDate { get; set; }
    public BadgeTier Tier { get; set; }

    // FK + navigation (dependent side of the One-to-One)
    public int AttendeeId { get; set; }
    public Attendee Attendee { get; set; } = null!;
}