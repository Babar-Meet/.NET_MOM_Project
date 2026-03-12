using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class MeetingVenueModel
    {
        [Key]
        public int MeetingVenueID { get; set; }

        [Required(ErrorMessage = "Meeting venue name is required")]
        [MaxLength(200, ErrorMessage = "Meeting venue name cannot exceed 200 characters")]
        public string MeetingVenueName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Creation date is required")]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Modification date is required")]
        public DateTime Modified { get; set; }
    }
}