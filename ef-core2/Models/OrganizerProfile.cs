using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ef_core2.Models;

    // Technique: Fluent API (directly inside OnModelCreating)
    public class OrganizerProfile
    {
        public int Id { get; set; }
        public string? Biography { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? LogoUrl { get; set; }

        // FK + navigation (dependent side of the One-to-One)
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; } = null!;
    }

