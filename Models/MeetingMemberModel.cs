using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class MeetingMemberModel
    {
        [Key]
        public int MeetingMemberID { get; set; }

        [Required(ErrorMessage = "Meeting is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a meeting")]
        public int MeetingID { get; set; }

        [Required(ErrorMessage = "Staff is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a staff member")]
        public int StaffID { get; set; }

        // Display properties (populated from JOINs, not submitted by form)
        public string? StaffName { get; set; }
        public DateTime? MeetingDate { get; set; }

        public bool IsPresent { get; set; }

        [MaxLength(250, ErrorMessage = "Remarks cannot exceed 250 characters")]
        public string? Remarks { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}