using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class MeetingMemberModel
    {
        [Key]
        public int MeetingMemberID { get; set; }

        [Required(ErrorMessage = "Meeting ID is required")]
        public int MeetingID { get; set; }

        [Required(ErrorMessage = "Staff ID is required")]
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