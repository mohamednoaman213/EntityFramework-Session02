using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef_core2.Models;

// Technique: Data Annotations only
[Table("EventOrganizers")]
public class Organizer
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(150)]
    public string? CompanyName { get; set; }   // optional

    public bool IsVerified { get; set; }

    // Navigation properties
    public OrganizerProfile? Profile { get; set; }          // One-to-One
    public ICollection<Event> Events { get; set; } = new List<Event>(); // One-to-Many
}