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
        public int MeetingVenueID { get; set; }

        [Required(ErrorMessage = "Meeting type is required")]
        public int MeetingTypeID { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int DepartmentID { get; set; }

        // Display names (populated from JOINs, not submitted by form)
        public string? MeetingVenueName { get; set; }
        public string? MeetingTypeName { get; set; }
        public string? DepartmentName { get; set; }

        [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string? MeetingDescription { get; set; }

        [MaxLength(250, ErrorMessage = "Document path cannot exceed 250 characters")]
        public string? DocumentPath { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public bool IsCancelled { get; set; }

        public DateTime? CancellationDateTime { get; set; }

        [MaxLength(250, ErrorMessage = "Cancellation reason cannot exceed 250 characters")]
        public string? CancellationReason { get; set; }
    }
}