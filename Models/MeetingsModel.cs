using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class MeetingsModel
    {
        [Key]
        public int MeetingID { get; set; }

        [Required(ErrorMessage = "Meeting date is required")]
        public DateTime MeetingDate { get; set; }

        [Required(ErrorMessage = "Meeting venue is required")]
        [MaxLength(200, ErrorMessage = "Meeting venue cannot exceed 200 characters")]
        public string MeetingVenue { get; set; }

        [Required(ErrorMessage = "Meeting type is required")]
        [MaxLength(50, ErrorMessage = "Meeting type cannot exceed 50 characters")]
        public string MeetingType { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [MaxLength(100, ErrorMessage = "Department cannot exceed 100 characters")]
        public string Department { get; set; }

        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? MeetingDescription { get; set; }

        [MaxLength(500, ErrorMessage = "Document path cannot exceed 500 characters")]
        public string? DocumentPath { get; set; }

        [Required(ErrorMessage = "Creation date is required")]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Modification date is required")]
        public DateTime Modified { get; set; }

        public bool IsCancelled { get; set; }

        public DateTime? CancellationDateTime { get; set; }

        [MaxLength(500, ErrorMessage = "Cancellation reason cannot exceed 500 characters")]
        public string? CancellationReason { get; set; }
    }
}