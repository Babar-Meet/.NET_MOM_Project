using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class DepartmentModel
    {
        [Key]
        [Required(ErrorMessage = "Department ID is required")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Department name must be between 2 and 100 characters")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Creation date is required")]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Modification date is required")]
        public DateTime Modified { get; set; }
    }
}