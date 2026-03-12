using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class StaffModel
    {
        [Key]
        public int StaffID { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a department")]
        public int DepartmentID { get; set; }

        // Display name (populated from JOIN, not submitted by form)
        public string? DepartmentName { get; set; }

        [Required(ErrorMessage = "Staff name is required")]
        [MaxLength(50, ErrorMessage = "Staff name cannot exceed 50 characters")]
        public string StaffName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mobile number is required")]
        [MaxLength(20, ErrorMessage = "Mobile number cannot exceed 20 characters")]
        public string MobileNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required")]
        [MaxLength(50, ErrorMessage = "Email address cannot exceed 50 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string EmailAddress { get; set; } = string.Empty;

        [MaxLength(250, ErrorMessage = "Remarks cannot exceed 250 characters")]
        public string? Remarks { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}