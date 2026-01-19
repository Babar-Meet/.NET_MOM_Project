using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class MeetingMemberModel
    {
        [Key]
        public int MeetingMemberID { get; set; }

        [Required(ErrorMessage = "Meeting ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Meeting ID must be a positive number")]
        public int MeetingID { get; set; }

        [Required(ErrorMessage = "Staff ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Staff ID must be a positive number")]
        public int StaffID { get; set; }

        public bool IsPresent { get; set; }

        [MaxLength(500, ErrorMessage = "Remarks cannot exceed 500 characters")]
        public string? Remarks { get; set; }

        [Required(ErrorMessage = "Creation date is required")]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Modification date is required")]
        public DateTime Modified { get; set; }
    }
}