using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class MeetingTypeModel
    {
        [Key]
        public int MeetingTypeID { get; set; }

        [Required(ErrorMessage = "Meeting type name is required")]
        [MaxLength(100, ErrorMessage = "Meeting type name cannot exceed 100 characters")]
        public string MeetingTypeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Remarks are required")]
        [MaxLength(500, ErrorMessage = "Remarks cannot exceed 500 characters")]
        public string Remarks { get; set; } = string.Empty;

        [Required(ErrorMessage = "Creation date is required")]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Modification date is required")]
        public DateTime Modified { get; set; }
    }
}