using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class StaffModel
    {
        [Key]
        public int StaffID { get; set; }

        [Required(ErrorMessage = "Department ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Department ID must be a positive number")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Staff name is required")]
        [MaxLength(100, ErrorMessage = "Staff name cannot exceed 100 characters")]
        public string StaffName { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [MaxLength(15, ErrorMessage = "Mobile number cannot exceed 15 characters")]
        [RegularExpression(@"^[0-9+\-()\s]*$", ErrorMessage = "Invalid mobile number format")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [MaxLength(100, ErrorMessage = "Email address cannot exceed 100 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string EmailAddress { get; set; }

        [MaxLength(500, ErrorMessage = "Remarks cannot exceed 500 characters")]
        public string? Remarks { get; set; }

        [Required(ErrorMessage = "Creation date is required")]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Modification date is required")]
        public DateTime Modified { get; set; }
    }
}