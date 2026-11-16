using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_core2.Models
{
    

    // Technique: Fluent API (separate configuration class)
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }   
        public int MaxAttendees { get; set; }

        // FK + navigation 
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; } = null!;
    }
}
